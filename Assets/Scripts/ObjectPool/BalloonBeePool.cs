using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBeePool : BaseObjectPool<BalloonBeePool, GameObject>
{
    [SerializeField] GameObject BalloonBee;

    protected override GameObject getPrefab()
    {
        return BalloonBee;
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
