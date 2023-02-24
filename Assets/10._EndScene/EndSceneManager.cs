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
    [SerializeField] Button btn_Exit;

    public string startSceneName = "0.SelectModeScene";
    //highscore일때만 보여주는거
    public GameObject HighScoreImage;
    int bestScore;

    public int rewardStar;


    private void Start()
    {
        StartCoroutine(CO_ActiveButton());
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().sortingLayerName = "UI";

        if (GameDatas.Inst.mode == Mode.COLLABORATION)
        {
            GameManager.Inst.ScoreSet(GameDatas.Inst.score);
            myScoreNameText.text = "최고기록";
            scoreText.text = $"{bestScore}";
            nameTMP.text = $"이번 기록 : {GameDatas.Inst.score}";
            switch (GameDatas.Inst.score)
            {
                case (< 650):
                    rewardStar = 5;
                    break;
                case (< 700):
                    rewardStar = 8;
                    break;
                default:
                    rewardStar = 12;
                    break;
            }
        }
        else // 개인모드일 때
        {
            myScoreNameText.text = "내점수";
            scoreText.text = $"{GameDatas.Inst.score}";
            nameTMP.text = "아이디가 나와라";
            switch (GameDatas.Inst.difficulty)
            {
                case DIFFICULTY.EASY:
                    switch (GameDatas.Inst.score)
                    {
                        case (< 850):
                            rewardStar = 5;
                            break;
                        case (< 1000):
                            rewardStar = 8;
                            break;
                        default:
                            rewardStar = 12;
                            break;
                    }
                    break;
                case DIFFICULTY.NORMAL:
                    switch (GameDatas.Inst.score)
                    {
                        case (< 1000):
                            rewardStar = 5;
                            break;
                        case (< 1300):
                            rewardStar = 8;
                            break;
                        default:
                            rewardStar = 12;
                            break;
                    }
                    break;
                case DIFFICULTY.HARD:
                    switch (GameDatas.Inst.score)
                    {
                        case (< 1100):
                            rewardStar = 5;
                            break;
                        case (< 1300):
                            rewardStar = 8;
                            break;
                        default:
                            rewardStar = 12;
                            break;
                    }
                    break;
                case DIFFICULTY.MASTER:
                    switch (GameDatas.Inst.score)
                    {
                        case (< 1000):
                            rewardStar = 5;
                            break;
                        case (< 1200):
                            rewardStar = 8;
                            break;
                        default:
                            rewardStar = 12;
                            break;
                    }
                    break;
            }
        }
        
        
        //이름바꿔줘야함
        //nameTMP.text = GameData.Inst.;
        //HighScore일때 처리 해아함
        bool isHighScore = false;
        HighScoreImage.SetActive(isHighScore);

        
        

        rewardStarText.text = "X"+rewardStar;
        //reward 실제 변경 함수는 이쪽에 추가
    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        DictionaryPool.Inst.DestroyMySelp();
        SceneManager.LoadScene(startSceneName);   
    }

    /// <summary>
    /// 5초 후에 버튼 활성화되는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_ActiveButton()
    {
        yield return new WaitForSeconds(5f);
        btn_Exit.interactable = true;
    }
}
