using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Water : Balloon
{
    private void OnEnable()
    {
        Floating();
    }

    protected override void Update()
    {
        base.Update();
    }
    // ��ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);

        // �� �����̴� 15�ۼ�Ʈ ����
        UIManager.Inst.UpdateWaterSlider(0.15f);

        // �� ������Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // �� ȣ�� ����
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(9, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
    }
}
