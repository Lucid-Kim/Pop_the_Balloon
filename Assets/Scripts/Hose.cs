using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(Release), 2f);
    }

    void Release()
    {
        HosePool.Inst.Release(this.gameObject);
    }
}
