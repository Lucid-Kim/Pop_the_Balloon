using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBalloonParticle : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(Release), 1f);
    }

    void Release()
    {
        SunBalloonParticlePool.Inst.Release(this.gameObject);
    }
}
