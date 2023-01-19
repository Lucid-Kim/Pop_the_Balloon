using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedParticle : Particle
{
    private void OnEnable()
    {
        base.DelayRelease(1f);
    }

}
