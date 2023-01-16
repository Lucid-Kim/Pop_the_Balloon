using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEffect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(Release), 1f);
    }

    void Release()
    {
        FlowerBalloonParticlePool.Inst.Release(this.gameObject);
    }
}
