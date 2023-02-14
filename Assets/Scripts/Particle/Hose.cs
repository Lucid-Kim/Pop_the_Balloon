using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : Particle
{
    private void OnEnable()
    {
        SoundManager.Inst.PlaySFX("WaterSFX");
        base.DelayRelease(2f);
    }

}
