using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Shit : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonShitPool.Inst.Release(gameObject);
        }
    }
    // ¶Ë Ç³¼± Å¬¸¯ÇßÀ» ¶§
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(-8.0f, -1f);
        BalloonShitPool.Inst.Release(this.gameObject);
        BalloonFertilizerPool.Inst.Get(new Vector2(ranX, -4));
    }
}
