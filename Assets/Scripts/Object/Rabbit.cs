using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour, Object_Interactable
{
    float bloomPosX = 0; // ������ ���� x ��ǥ
    float moveSpeed = 5f; // �����̴� �ӵ�
    Vector3 myPos;
    bool isMove; // �����̴°� �������� Ȯ��
    int rabbitNum; // �䳢 ��ġ�� ��Ÿ���� ����
    float oldTime;
    int listCount; // bloom List�� ����
    int idx; // ������ ���� �����ϴ� �ε���
    float minDis; // �ּҰŸ��� ���� ���� �� ����ϴ� ����
    bool isClick; // Ŭ���� �ߴ��� ��Ÿ���� ����
    private void OnEnable()
    {
        isMove = true;
        rabbitNum = RabbitSpawner.Inst.idx;
        idx = Random.Range(0, GameManager.Inst.bloom.Count); // �Ǿ ���� �����ϴ� �ε���
        bloomPosX = GameManager.Inst.bloom[idx].transform.position.x; // �ش� ���� x ��ǥ
        minDis = 100;
        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isMove);
        //Debug.Log(RabbitSpawner.Inst.idx);
        if (isMove == true && rabbitNum == 1) // ������ �� �ְ� �����ʿ��� �������� ��
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= bloomPosX + 1) // �ش� �� �����ʿ��� ���缭 �ִϸ��̼� �߰� ����
            {
                this.gameObject.layer = 3; // Ŭ���� �� �ִ� ���̾�� ����
                isMove = false;
                return;
            }
        }
        else if (isMove == true && rabbitNum == 0)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= bloomPosX - 1)
            {
                this.gameObject.layer = 3;
                isMove = false;
                return;
            }
        }

        if (isMove == false && rabbitNum == 1) // ������ �� ���� �����̸� �����ʿ��� �������� ��
        {   
            oldTime += Time.deltaTime;
            if (oldTime >= 5f)
            {
                listCount = GameManager.Inst.bloom.Count;
                if (isClick == false && GameManager.Inst.bloom.Count != 0)
                {
                    BloomingPool.Inst.Release(GameManager.Inst.bloom[idx]);
                    GameManager.Inst.bloom.RemoveAt(idx);
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
                    BloomingPool.Inst.Release(GameManager.Inst.bloom[idx]);
                    GameManager.Inst.bloom.RemoveAt(idx);
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
    /// ���� �԰��ִ� �䳢�� ��ġ���� �� ���ư��� ����� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_RabbitAttack()
    {
        if (rabbitNum == 1) // �����ʿ��� ���°� Ŭ�� ���� ��
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

    void DeleteRabbit()
    {
        // �������� ���� �� ������� ����
        if (transform.position.x < -9)
        {
            oldTime = 0;
            RabbitPool.Inst.Release(this.gameObject);
        }
        // ���������� ���� �� ������� ����
        if (transform.position.x > 9)
        {
            oldTime = 0;
            RabbitPool.Inst.Release(this.gameObject);
        }
    }
    

}
