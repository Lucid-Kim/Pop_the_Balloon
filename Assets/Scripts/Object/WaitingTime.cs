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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReduceTime();
    }

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
