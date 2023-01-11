using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomingPool : BaseObjectPool<BloomingPool, GameObject>
{
    [SerializeField] GameObject blooming;

    protected override GameObject getPrefab()
    {
        return blooming;
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
