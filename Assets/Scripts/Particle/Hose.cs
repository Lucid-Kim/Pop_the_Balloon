using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : Particle
{
    private void OnEnable()
    {
        base.DelayRelease(2f);
    }

}
