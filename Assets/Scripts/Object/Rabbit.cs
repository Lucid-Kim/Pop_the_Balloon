using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour, Object_Interactable
{
    float ranX1 = 0; // 오른쪽 랜덤 값
    float ranX2 = 0; // 왼쪽 랜덤 값
    float moveSpeed = 5f; // 움직이는 속도
    Vector3 myPos;
    bool isMove; // 움직이는게 가능한지 확인
    int rabbitNum; // 토끼 위치를 나타내는 숫자
    float oldTime;
    int listCount; // bloom List의 갯수
    int idx = 0; // 최소거리의 객체의 인덱스
    float minDis; // 최소거리의 꽃을 구할 때 사용하는 변수
    bool isClick; // 클릭을 했는지 나타내는 변수
    private void OnEnable()
    {
        isMove = true;
        rabbitNum = RabbitSpawner.Inst.idx;
        ranX1 = Random.Range(1, 9);
        ranX2 = Random.Range(-8, 0);
        minDis = 100;
        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isMove);
        //Debug.Log(RabbitSpawner.Inst.idx);
        if (isMove == true && rabbitNum == 1) // 움직일 수 있고 오른쪽에서 출현했을 때
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= ranX1) // 해당 x좌표에서 멈춰서 애니메이션 추가 예정
            {
                this.gameObject.layer = 3; // 클릭할 수 있는 레이어로 변경
                isMove = false;
                return;
            }
        }
        else if (isMove == true && rabbitNum == 0)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= ranX2)
            {
                this.gameObject.layer = 3;
                isMove = false;
                return;
            }
        }

        if (isMove == false && rabbitNum == 1) // 움직일 수 없는 상태이며 오른쪽에서 출현했을 때
        {   
            oldTime += Time.deltaTime;
            if (oldTime >= 5f)
            {
                listCount = GameManager.Inst.bloom.Count;
                if (isClick == false && GameManager.Inst.bloom.Count != 0)
                {
                    Debug.Log(GameManager.Inst.bloom[SearchFlowerIdx()].transform.position);
                    BloomingPool.Inst.Release(GameManager.Inst.bloom[SearchFlowerIdx()]);
                    GameManager.Inst.bloom.RemoveAt(SearchFlowerIdx());
                    isClick = true;
                }
                this.gameObject.layer = 0;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
        else if (isMove == false && rabbitNum == 0)
        {
            oldTime += Time.deltaTime;
            if (oldTime >= 5f)
            {
                listCount = GameManager.Inst.bloom.Count;
                if (isClick == false && GameManager.Inst.bloom.Count != 0)
                {
                    Debug.Log(GameManager.Inst.bloom[SearchFlowerIdx()].transform.position);
                    BloomingPool.Inst.Release(GameManager.Inst.bloom[SearchFlowerIdx()]);
                    GameManager.Inst.bloom.RemoveAt(SearchFlowerIdx());
                    isClick = true;
                }
                this.gameObject.layer = 0;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
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
            this.gameObject.layer = 0;
            while (true)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            isClick = true;
            this.gameObject.layer = 0;
            while (true)
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    public int SearchFlowerIdx()
    {
        Debug.Log(listCount);
        for (int i = 0; i < listCount; i++)
        {
            // 거리가 최소인 꽃 확인
            if (minDis > Vector3.Distance(GameManager.Inst.bloom[i].transform.position, this.transform.position))
            {
                minDis = Vector3.Distance(GameManager.Inst.bloom[i].transform.position, this.transform.position);
                idx = i;
                Debug.Log("인덱스 " + idx);
            }
        }
        return idx;
    }

    void DeleteRabbit()
    {
        // 왼쪽으로 갔을 때 사라지는 로직
        if (transform.position.x < -9)
        {
            oldTime = 0;
            RabbitPool.Inst.Release(this.gameObject);
        }
        // 오른쪽으로 갔을 때 사라지는 로직
        if (transform.position.x > 9)
        {
            oldTime = 0;
            RabbitPool.Inst.Release(this.gameObject);
        }
    }
    

}
