using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] Text scoreText;
    [SerializeField] Text rewardStarText;
    [SerializeField] Text myScoreNameText;

    public string startSceneName = "0.SelectModeScene";
    //highscore일때만 보여주는거
    public GameObject HighScoreImage;
    int bestScore;

    public int rewardStar;


    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().sortingLayerName = "UI";

        if (GameDatas.Inst.mode == Mode.COLLABORATION)
        {
            GameManager.Inst.ScoreSet(GameDatas.Inst.score);
            myScoreNameText.text = "최고기록";
            scoreText.text = $"{bestScore}";
            nameTMP.text = $"이번 기록 : {GameDatas.Inst.score}";
        }
        else
        {
            myScoreNameText.text = "내점수";
            scoreText.text = $"{GameDatas.Inst.score}";
            nameTMP.text = "아이디가 나와라";
        }
        
        
        //이름바꿔줘야함
        //nameTMP.text = GameData.Inst.;
        //HighScore일때 처리 해아함
        bool isHighScore = false;
        HighScoreImage.SetActive(isHighScore);


        //보상 변경은 여기서 
        switch(GameDatas.Inst.score)
        {
            case (< 300):
                rewardStar = 5;
                break;
            case (<450):
                rewardStar = 8;
                break;
            default:
                rewardStar = 12;
                break;
        }

        rewardStarText.text = "X"+rewardStar;
        //reward 실제 변경 함수는 이쪽에 추가
    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        DictionaryPool.Inst.DestroyMySelp();
        SceneManager.LoadScene(startSceneName);   
    }


}
