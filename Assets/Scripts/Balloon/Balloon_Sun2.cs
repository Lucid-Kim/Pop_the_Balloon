using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Sun2 : Balloon
{
    protected override void Update()
    {

    }
    public override void Interact()
    {
        base.Interact();
        GameManager.Inst.Region2AddCount(-1);
        // �� �� ȿ�� ����
        GameObject sunLight = DictionaryPool.Inst.Instantiate(obj[1], new Vector3(-6, 11, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        sunLight.transform.rotation = Quaternion.Euler(68.9f, 113, 90);

        // ���� �ö󰡴� �ؽ�Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);

        // ���ӸŴ������� �����ϴ� ���� �ø���
        GameManager.Inst.score += 10;

        // UI �ؽ�Ʈ ���� ����
        UIManager.Inst.UpdateScore();
    }
}
