using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedParticle : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(Release), 1f);
    }

    void Release()
    {
        SeedBalloonParticlePool.Inst.Release(this.gameObject);
    }
}
