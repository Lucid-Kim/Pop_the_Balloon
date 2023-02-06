using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower1 : Balloon
{
    int balloonIdx;
    private void OnEnable()
    {
        Floating();
    }

    protected override void Update()
    {
        base.Update();
    }
    // 1���� ��ǳ�� ��ġ���� ��
    public override void Interact()
    {
        base.Interact();
        balloonIdx = Random.Range(1, 6);
        if (GameManager.Inst.Region2Spawned() == true)
        {
            // 2������ ��ǳ�� ����
            DictionaryPool.Inst.Instantiate(obj[balloonIdx], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
    }
}
