using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitPool : BaseObjectPool<RabbitPool, GameObject>
{
    [SerializeField] GameObject rabbit;

    protected override GameObject getPrefab()
    {
        return rabbit;
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
