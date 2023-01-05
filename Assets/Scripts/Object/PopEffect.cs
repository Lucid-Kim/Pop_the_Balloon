using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEffect : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(CO_DeleteEffect());
    }
    
    IEnumerator CO_DeleteEffect()
    {
        yield return new WaitForSeconds(0.5f);
        PopEffectPool.Inst.Release(this.gameObject);
    }
}
