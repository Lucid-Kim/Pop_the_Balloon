using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonWaterPool : BaseObjectPool<BalloonWaterPool, GameObject>
{
    [SerializeField] GameObject BalloonWater;

    protected override GameObject getPrefab()
    {
        return BalloonWater;
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
