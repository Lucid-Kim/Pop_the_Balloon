using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Seed : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    // ���� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(1.0f, 8.0f); // �������� ��Ÿ���� x��ǥ
        //ranNum = Random.Range(0, 2);
        DictionaryPool.Inst.Release(gameObject);

        // �� ǳ�� 1,2 �߿� �������� ����
        //DictionaryPool.Inst.Instantiate(obj[ranNum], new Vector2(ranX, -4), Quaternion.identity, DictionaryPool.Inst.transform); 

        // ���� ǳ�� ȿ�� ����
        DictionaryPool.Inst.Instantiate(obj[2], gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
    }
}
