using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Bee : Balloon
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
        DictionaryPool.Inst.Destroy(this.gameObject);
        // �� ������Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[0], this.gameObject.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);
        
    }

}
