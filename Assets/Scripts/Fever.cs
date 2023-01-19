using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fever : MonoBehaviour
{
    // ��¦�̴� Fever ����
    TextMeshProUGUI feverText;
    private void Awake()
    {
        feverText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ranColor1 = Random.Range(0, 255); // RGB������ R�� ��
        int ranColor2 = Random.Range(0, 255); // RGB������ G�� ��
        int ranColor3 = Random.Range(0, 255); // RGB������ B�� ��
        feverText.color = new Color(ranColor1 / 255f, ranColor2 / 255f, ranColor3 / 255f);
    }
}
