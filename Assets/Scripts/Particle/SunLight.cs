using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(Release), 5f);
    }

    void Release()
    {
        SunLightPool.Inst.Release(this.gameObject);
    }
}