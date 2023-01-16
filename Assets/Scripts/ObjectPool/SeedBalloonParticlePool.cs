using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBalloonParticlePool : BaseObjectPool<SeedBalloonParticlePool, GameObject>
{
    [SerializeField] GameObject SeedBalloonParticle;

    protected override GameObject getPrefab()
    {
        return SeedBalloonParticle;
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
