using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    float secs = 60;
    TextMeshProUGUI text_Time;
    private void Awake()
    {
        text_Time = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        //StartCoroutine(UIManager.Inst.CO_ReduceSlider());
    }

    void Update()
    {
        if (GameManager.Inst.isGameover == false)
        {
            ReduceTime();
        }
    }
    /// <summary>
    /// �ð� ���ҿ� ���� �ؽ�Ʈ ���� �Լ�
    /// </summary>
    void ReduceTime()
    {
        secs -= Time.deltaTime;
        TimeSpan t = TimeSpan.FromSeconds(secs);

        string answer = string.Format("{0:D1}", t.Seconds);
        text_Time.text = answer;
        if (secs <= 0)
        {
            secs = 0;
            GameManager.Inst.EndGame();
        }
    }


}
