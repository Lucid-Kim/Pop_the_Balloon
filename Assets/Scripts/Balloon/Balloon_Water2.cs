using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Water2 : Balloon
{
    protected override void Update()
    {
        
    }
    public override void Interact()
    {
        base.Interact();
        
        GameManager.Inst.Region2AddCount(-1);
        // �� �Ѹ��� ȿ�� ����
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(9, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // ���� �ö󰡴� �ؽ�Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 2, 0)), Quaternion.identity, GameObject.Find("UI").transform);

        // ���ӸŴ������� �����ϴ� ���� �ø���
        GameManager.Inst.score += 10;

        // UI �ؽ�Ʈ ���� ����
        UIManager.Inst.UpdateScore();
    }

}
