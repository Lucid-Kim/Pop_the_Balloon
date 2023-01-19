using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitingTime : MonoBehaviour
{
    float waitTime = 3.5f;
    TextMeshProUGUI text_WaitTime;

    private void Awake()
    {
        text_WaitTime = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        ReduceTime();
    }

    /// <summary>
    /// 시작전 대기시간을 알려주는 함수
    /// </summary>
    void ReduceTime()
    {
        waitTime -= Time.deltaTime;
        text_WaitTime.text = waitTime.ToString("N0");
        if (waitTime <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
