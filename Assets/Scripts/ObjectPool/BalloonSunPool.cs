using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSunPool : BaseObjectPool<BalloonSunPool, GameObject>
{
    [SerializeField] GameObject BalloonSun;

    protected override GameObject getPrefab()
    {
        return BalloonSun;
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
