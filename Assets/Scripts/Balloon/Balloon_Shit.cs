using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Shit : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }
    // �� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(-8.0f, -1f); // ������ ��Ÿ���� x��ǥ

        // �� ǳ�� ��ġ�� ��� ǳ�� ����
        DictionaryPool.Inst.Instantiate(obj[0], new Vector2(ranX, -4), Quaternion.identity, DictionaryPool.Inst.transform);

        // ǳ�� ��ġ�� ȿ�� ���
        DictionaryPool.Inst.Instantiate(obj[1], this.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
        DictionaryPool.Inst.Release(this.gameObject);
    }
}
