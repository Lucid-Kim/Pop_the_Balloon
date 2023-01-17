using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Sun : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            DictionaryPool.Inst.Destroy(this.gameObject);
        }
    }

    // ��ǳ�� Ŭ���� �����ؾ��ϴ� �͵� �Է��� ��
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);
        UIManager.Inst.UpdateSunSlider(0.15f);
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); // �� ǳ�� ȿ�� ����
        GameObject sunLight = DictionaryPool.Inst.Instantiate(obj[1], new Vector3(-6, 11, 0), Quaternion.identity, DictionaryPool.Inst.transform); // �� �� ȿ�� ����
        sunLight.transform.rotation = Quaternion.Euler(68.9f, 113, 90);
    }
}
