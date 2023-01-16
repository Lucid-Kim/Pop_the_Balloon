using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HosePool : BaseObjectPool<HosePool, GameObject>
{
    [SerializeField] GameObject Hose;

    protected override GameObject getPrefab()
    {
        return Hose;
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
