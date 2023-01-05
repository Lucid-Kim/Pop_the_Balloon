using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPool : BaseObjectPool<FlowerPool, GameObject>
{
    [SerializeField] GameObject flower;

    protected override GameObject getPrefab()
    {
        return flower;
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
