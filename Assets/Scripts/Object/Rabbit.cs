using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour, Object_Interactable
{
    float bloomPosX = 0; // 선정된 꽃의 x 좌표
    float moveSpeed = 5f; // 움직이는 속도
    bool isMove; // 움직이는게 가능한지 확인
    int rabbitNum; // 토끼 출발위치를 나타내는 숫자
    float oldTime; // 토끼가 꽃을 먹는 시간 설정을 위한 시간
    int listCount; // bloom List의 갯수
    int idx; // 랜덤한 꽃을 선정하는 인덱스
    bool isClick; // 클릭을 했는지 나타내는 변수
    SpriteRenderer sr; // 토끼의 움직이는 방향을 나타내기 위한 SpriteRenderer
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        isMove = true;
        rabbitNum = RabbitSpawner.Inst.idx;
        idx = Random.Range(0, GameManager.Inst.bloom.Count); // 피어난 꽃을 선정하는 인덱스
        bloomPosX = GameManager.Inst.bloom[idx].transform.position.x; // 해당 꽃의 x 좌표
        isClick = false;
    }

    void Update()
    {
        if (isMove == true && rabbitNum == 1) // 움직일 수 있고 오른쪽에서 출현했을 때
        {
            sr.flipX = true;
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= bloomPosX + 1) // 해당 꽃 오른쪽에서 멈춰서 애니메이션 추가 예정
            {
                this.gameObject.layer = 3; // 클릭할 수 있는 레이어로 변경
                isMove = false;
                return;
            }
        }
        else if (isMove == true && rabbitNum == 0) // 움직일 수 있고 왼쪽에서 출현했을 때
        {
            sr.flipX = false;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= bloomPosX - 1) // 해당 꽃 왼쪽에서 멈춰서 애니메이션 추가 예정
            {
                this.gameObject.layer = 3;
                isMove = false;
                return;
            }
        }

        if (isMove == false && rabbitNum == 1) // 움직일 수 없는 상태이며 오른쪽에서 출현했을 때(멈춰서 꽃을 먹는 애니메이션)
        {   
            oldTime += Time.deltaTime;
            if (oldTime >= 5f)
            {
                listCount = GameManager.Inst.bloom.Count;
                if (isClick == false && listCount != 0)
                {
                    DictionaryPool.Inst.Destroy(GameManager.Inst.bloom[idx]); // 선택된 꽃 삭제
                    GameManager.Inst.bloom.RemoveAt(idx);
                    isClick = true;
                }
                this.gameObject.layer = 0; // 
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                sr.flipX = false;
            }
        }
        else if (isMove == false && rabbitNum == 0) // 움직일 수 없는 상태이며 왼쪽에서 출현했을 때(멈춰서 꽃을 먹는 애니메이션)
        {
            oldTime += Time.deltaTime;
            if (oldTime >= 5f)
            {
                listCount = GameManager.Inst.bloom.Count;
                if (isClick == false && listCount != 0)
                {
                    DictionaryPool.Inst.Destroy(GameManager.Inst.bloom[idx]); // 선택된 꽃 삭제
                    GameManager.Inst.bloom.RemoveAt(idx);
                    isClick = true;
                }
                this.gameObject.layer = 0;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                sr.flipX = true;
            }
        }
        DeleteRabbit();
    }

    public void Interact()
    {
        StartCoroutine(nameof(CO_RabbitAttack));
    }

    /// <summary>
    /// 꽃을 먹고있는 토끼를 터치했을 때 돌아가게 만드는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_RabbitAttack()
    {
        if (rabbitNum == 1) // 오른쪽에서 나온걸 클릭 했을 때
        {
            isClick = true;
            sr.flipX = false;
            this.gameObject.layer = 0;
            while (true)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else // 왼쪽에서 나온걸 클릭 했을 때
        {
            isClick = true;
            sr.flipX = true;
            this.gameObject.layer = 0;
            while (true)
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
    /// <summary>
    /// 토끼가 일정 지역을 갔을 때 사라지는 함수
    /// </summary>
    void DeleteRabbit()
    {
        // 왼쪽으로 갔을 때 사라지는 로직
        if (transform.position.x < -9)
        {
            oldTime = 0;
            DictionaryPool.Inst.Destroy(this.gameObject);
        }
        // 오른쪽으로 갔을 때 사라지는 로직
        if (transform.position.x > 9)
        {
            oldTime = 0;
            DictionaryPool.Inst.Destroy(this.gameObject);
        }
    }
    

}
