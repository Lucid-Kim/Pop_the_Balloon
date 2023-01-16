using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Seed : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonSeedPool.Inst.Release(gameObject);
        }
    }

    // ¾¾¾Ñ Ç³¼± Å¬¸¯ÇßÀ» ¶§
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(1.0f, 8.0f);
        SeedBalloonParticlePool.Inst.Get(gameObject.transform.position + new Vector3(0, 2, 0));
        BalloonSeedPool.Inst.Release(this.gameObject);
        BalloonFlowerPool.Inst.Get(new Vector2(ranX, -4));
    }
}
