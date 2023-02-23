using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("인게임")]
    [SerializeField] TextMeshProUGUI ingameScore; // 인게임 안에서 점수를 나타내는 텍스트
    [SerializeField] TextMeshProUGUI addedScore;  // 풍선을 터치했을 때 나오는 텍스트
    
    [Header("게임오버")]
    [SerializeField] GameObject restartBtn; // 재시작 버튼
    
    Coroutine rankWindowOn; // 랭크를 나타내는 코루틴

    [Header("점수")]
    [SerializeField] TextMeshProUGUI bestScoreText; // 최고점수를 나타내는 텍스트
    
    string keyName = "BestScore";
    int bestScore = 0;

    [SerializeField] Image feverText; // 피버타임을 알려주는 텍스트

    /// <summary>
    /// 인게임에서 스코어를 나타내는 함수
    /// </summary>
    public void UpdateScore()
    {
        ingameScore.text = GameManager.Inst.score.ToString();
    }
    

    public void FeverTextActive(bool isOn = true)
    {
        feverText.gameObject.SetActive(isOn);
    }

    
    


}
