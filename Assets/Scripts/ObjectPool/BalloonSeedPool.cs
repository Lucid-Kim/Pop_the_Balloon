using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSeedPool : BaseObjectPool<BalloonSeedPool, GameObject>
{
    [SerializeField] GameObject BalloonSeed;

    protected override GameObject getPrefab()
    {
        return BalloonSeed;
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
