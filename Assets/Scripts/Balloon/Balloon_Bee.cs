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

    // ¹ú Ç³¼± Å¬¸¯ÇßÀ» ¶§
    public override void Interact()
    {
        base.Interact();
        BalloonBeePool.Inst.Release(this.gameObject);
    }
}
