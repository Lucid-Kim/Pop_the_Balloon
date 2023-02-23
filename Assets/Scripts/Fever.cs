using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Fever : MonoBehaviour
{
    float time = 0.002f;
    float hueValue = 0;
    
    /// <summary>
    /// 반짝이는 Fever 문구
    /// </summary>
    Image feverText;
    private void Awake()
    {
        feverText = GetComponent<Image>();
    }
    void Start()
    {
        StartCoroutine(CO_ChangColorText());
        
    }
    

    IEnumerator CO_ChangColorText()
    {
        for (int i = 0; i<7;i++)
        {
            hueValue = 0;
            while (hueValue < 1)
            {
                Color temp = Color.HSVToRGB(hueValue, 1, 1);
                feverText.color = temp;
                Debug.Log(temp);
                hueValue += (1f/360f);
            
                yield return new WaitForSeconds(time);
            }
        }
           
        
    }
}
