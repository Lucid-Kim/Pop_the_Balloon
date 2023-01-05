using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Bee : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonBeePool.Inst.Release(gameObject);
        }
    }

    // �� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        BalloonBeePool.Inst.Release(this.gameObject);
    }
}
