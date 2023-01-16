using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightPool : BaseObjectPool<SunLightPool, GameObject>
{
    [SerializeField] GameObject SunLight;

    protected override GameObject getPrefab()
    {
        return SunLight;
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
