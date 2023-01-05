using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunImage : MonoBehaviour
{
    
    private void OnEnable()
    {
        StartCoroutine(CO_DeleteSunImage());
    }

    IEnumerator CO_DeleteSunImage()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
