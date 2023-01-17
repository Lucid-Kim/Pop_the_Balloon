using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    int min = 1;
    float sec = 0.5f;
    float secs = 90;
    TextMeshProUGUI text_Time;
    private void Awake()
    {
        text_Time = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        StartCoroutine(UIManager.Inst.CO_ReduceSlider());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Inst.isGameover == false)
        {
            ReduceTime();
        }
    }

    void ReduceTime()
    {
        secs -= Time.deltaTime;
        TimeSpan t = TimeSpan.FromSeconds(secs);

        string answer = string.Format("{0:D1}:{1:D2}", t.Minutes, t.Seconds);
        text_Time.text = answer;
        if (secs <= 0)
        {
            secs = 0;
            GameManager.Inst.EndGame();
        }
    }


}
