using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBalloonParticlePool : BaseObjectPool<SunBalloonParticlePool, GameObject>
{
    [SerializeField] GameObject SunBalloonParticle;

    protected override GameObject getPrefab()
    {
        return SunBalloonParticle;
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
