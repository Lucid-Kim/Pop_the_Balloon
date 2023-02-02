using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text_Score;
    private void Awake()
    {
        text_Score = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //text_Score.text = "Á¡¼ö : " + (GameManager.Inst.bloom.Count * 10);
    }
}
