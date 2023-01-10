using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour, Object_Interactable
{
    float ranX1 = 0; // ������ ���� ��
    float ranX2 = 0; // ���� ���� ��
    float moveSpeed = 5f; // �����̴� �ӵ�
    Vector3 myPos;
    bool isMove; // �����̴°� �������� Ȯ��
    int rabbitNum; // �䳢 ��ġ�� ��Ÿ���� ����
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
        if (isMove == true && rabbitNum == 1) // ������ �� �ְ� �����ʿ��� �������� ��
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= ranX1)
            {
                this.gameObject.layer = 3; // Ŭ���� �� �ִ� ���̾�� ����
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

        if (isMove == false && rabbitNum == 1) // ������ �� ���� �����̸� �����ʿ��� �������� ��
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
        if (rabbitNum == 1) // �����ʿ��� ���°� Ŭ�� ���� ��
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
