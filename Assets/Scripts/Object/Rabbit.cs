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
    private void OnEnable()
    {
        isMove = true;
        rabbitNum = RabbitSpawner.Inst.idx;
        ranX1 = Random.Range(1, 9);
        ranX2 = Random.Range(-8, 0);
        //StartCoroutine(nameof(CO_RabbitMove));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMove);
        Debug.Log(RabbitSpawner.Inst.idx);
        if (isMove == true && rabbitNum == 1) // 움직일 수 있고 오른쪽에서 출현했을 때
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= ranX1)
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
            if (oldTime >= 3f)
            {
                this.gameObject.layer = 0;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                if (transform.position.x >= 9)
                {
                    RabbitPool.Inst.Release(this.gameObject);
                    oldTime = 0;
                }

            }
        }
        else if (isMove == false && rabbitNum == 0)
        {
            oldTime += Time.deltaTime;
            if (oldTime >= 3f)
            {
                this.gameObject.layer = 0;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                if (transform.position.x <= -9)
                {
                    RabbitPool.Inst.Release(this.gameObject);
                    oldTime = 0;
                }
            }
        }
    }

    public void Interact()
    {
        StartCoroutine(nameof(CO_RabbitAttack));
    }

    IEnumerator CO_RabbitAttack()
    {
        if (rabbitNum == 1) // 오른쪽에서 나온걸 클릭 했을 때
        {
            this.gameObject.layer = 0;
            while (true)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                yield return null;
                if (transform.position.x >= 9)
                {
                    oldTime = 0;
                    RabbitPool.Inst.Release(this.gameObject);
                }
            }
        }
        else
        {
            this.gameObject.layer = 0;
            while (true)
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                yield return null;
                if (transform.position.x <= -9)
                {
                    oldTime = 0;
                    RabbitPool.Inst.Release(this.gameObject);
                }
            }
        }
    }


    

}
