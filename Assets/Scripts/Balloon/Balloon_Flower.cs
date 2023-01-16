using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonFlowerPool.Inst.Release(gameObject);
        }
    }

    public override void Interact()
    {
        base.Interact();
        BalloonFlowerPool.Inst.Release(this.gameObject);
        FlowerPool.Inst.Get(this.gameObject.transform.position);
        FlowerBalloonParticlePool.Inst.Get(this.gameObject.transform.position + new Vector3(0, 2, 0));
    }

    
}
