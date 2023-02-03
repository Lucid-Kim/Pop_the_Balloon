using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : Particle
{
    private void OnEnable()
    {
        base.DelayRelease(1f);
    }
}
