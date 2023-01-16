using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitBalloonParticlePool : BaseObjectPool<ShitBalloonParticlePool, GameObject>
{
    [SerializeField] GameObject shitBalloonPrticle;

    protected override GameObject getPrefab()
    {
        return shitBalloonPrticle;
    }

    public override GameObject Get(Vector2 position)
    {
        return base.Get(position);
    }

    public override void Release(GameObject obj)
    {
        obj.transform.SetParent(transform);
        base.Release(obj);
    }
}
