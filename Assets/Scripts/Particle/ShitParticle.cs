using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitParticle : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(Release), 1f);
    }

    void Release()
    {
        DictionaryPool.Inst.Destroy(this.gameObject);
    }
}
