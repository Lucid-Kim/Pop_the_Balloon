using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomingPool : BaseObjectPool<BloomingPool, GameObject>
{
    [SerializeField] GameObject []blooming;
    FlowerPool flowerPool = null;
    int idx;
    private void Awake()
    {
        flowerPool = FindObjectOfType<FlowerPool>();
    }
    
    protected override GameObject getPrefab()
    {
        return blooming[idx];
    }

    public override GameObject Get(Vector2 position)
    {
        idx = flowerPool.flowerIdx;
        return base.Get(position);
    }

    public override void Release(GameObject obj)
    {
        obj.transform.SetParent(transform);
        base.Release(obj);
    }
}
