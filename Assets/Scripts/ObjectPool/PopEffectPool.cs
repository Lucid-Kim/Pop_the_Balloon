using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEffectPool : BaseObjectPool<PopEffectPool, GameObject>
{
    [SerializeField] GameObject popEffect;

    protected override GameObject getPrefab()
    {
        return popEffect;
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
