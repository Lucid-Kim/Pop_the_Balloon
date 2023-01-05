using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFertilizerPool : BaseObjectPool<BalloonFertilizerPool, GameObject>
{
    [SerializeField] GameObject BalloonFertilizer;

    protected override GameObject getPrefab()
    {
        return BalloonFertilizer;
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
