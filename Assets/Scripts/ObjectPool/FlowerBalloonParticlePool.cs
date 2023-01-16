using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBalloonParticlePool : BaseObjectPool<FlowerBalloonParticlePool, GameObject>
{
    [SerializeField] GameObject FlowerBalloonParticle;

    protected override GameObject getPrefab()
    {
        return FlowerBalloonParticle;
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
