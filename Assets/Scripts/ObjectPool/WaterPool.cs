using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPool : BaseObjectPool<WaterPool, GameObject>
{
    [SerializeField] GameObject water;

    protected override GameObject getPrefab()
    {
        return water;
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
