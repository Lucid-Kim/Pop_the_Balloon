using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : Particle
{
    private void OnEnable()
    {
        SoundManager.Inst.PlaySFX("SunSFX");
        base.DelayRelease(5f);
    }

}
