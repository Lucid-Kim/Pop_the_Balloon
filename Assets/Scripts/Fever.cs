using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fever : MonoBehaviour
{
    float time = 0;
    /// <summary>
    /// 반짝이는 Fever 문구
    /// </summary>
    TextMeshProUGUI feverText;
    private void Awake()
    {
        feverText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        StartCoroutine(CO_ChangColorText());
    }


    IEnumerator CO_ChangColorText()
    {
        while (time < 10)
        {
            int ranColor1 = Random.Range(0, 255); // RGB에서의 R의 값
            int ranColor2 = Random.Range(0, 255); // RGB에서의 G의 값
            int ranColor3 = Random.Range(0, 255); // RGB에서의 B의 값
            feverText.color = new Color(ranColor1 / 255f, ranColor2 / 255f, ranColor3 / 255f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
