using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPool : BaseObjectPool<FlowerPool, GameObject>
{
    [SerializeField] GameObject[] flower; // ≤…µÈ «¡∏Æ∆’
    public int flowerIdx; // ≤… ¿Œµ¶Ω∫
    protected override GameObject getPrefab()
    {
        return flower[flowerIdx];
    }

    public override GameObject Get(Vector2 position)
    {
        flowerIdx = Random.Range(0, 3);
        return base.Get(position);
    }

    public override void Release(GameObject obj)
    {
        obj.transform.SetParent(transform);
        base.Release(obj);
    }
}
