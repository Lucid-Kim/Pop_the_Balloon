using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunShine : MonoBehaviour
{
    
    private void OnEnable()
    {
        StartCoroutine(CO_DeleteObject());

    }
    void Update()
    {
        
    }
    IEnumerator CO_DeleteObject()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
