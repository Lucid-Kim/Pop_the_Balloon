using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower2 : Balloon
{
    protected override void Update()
    {

    }
    public override void Interact()
    {
        base.Interact();
        GameManager.Inst.Region2AddCount(-1);
        // �� ���� (����� ���������ε� ��ȹ���� ���� �ٲ�� ��ġ �ٲ������)
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        
        // ���� �ö󰡴� �ؽ�Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);

        // ���ӸŴ������� �����ϴ� ���� �ø���
        GameManager.Inst.score += 10;

        // UI �ؽ�Ʈ ���� ����
        UIManager.Inst.UpdateScore();
    }
}
