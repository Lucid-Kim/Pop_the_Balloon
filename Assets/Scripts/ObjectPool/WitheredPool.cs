using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitheredPool : BaseObjectPool<WitheredPool, GameObject>
{
    [SerializeField] GameObject Withered;

    protected override GameObject getPrefab()
    {
        return Withered;
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
