using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFlowerPool : BaseObjectPool<BalloonFlowerPool,GameObject>
{
    [SerializeField] GameObject[] BalloonFlower;
    int ballonFloweridx; // ≤…«≥º± ¿Œµ¶Ω∫

    protected override GameObject getPrefab()
    {
        ballonFloweridx = Random.Range(0, 2);
        return BalloonFlower[ballonFloweridx];
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
