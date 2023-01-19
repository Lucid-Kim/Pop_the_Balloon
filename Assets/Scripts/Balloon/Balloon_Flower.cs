using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower : Balloon
{
    public int ranBloomingNum;
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();
        // �� ���� �ε��� ����
        ranBloomingNum = Random.Range(0, 3);
        DictionaryPool.Inst.Release(this.gameObject);

        // �� 3���� �� �����ϰ� ����
        DictionaryPool.Inst.Instantiate(obj[ranBloomingNum], this.gameObject.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);

        // �� ǳ�� ��ġ����Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[3], this.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
    }

    
}
