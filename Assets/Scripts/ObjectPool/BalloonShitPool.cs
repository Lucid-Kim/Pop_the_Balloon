using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonShitPool : BaseObjectPool<BalloonShitPool, GameObject>
{
    [SerializeField] GameObject BalloonShit;

    protected override GameObject getPrefab()
    {
        return BalloonShit;
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
