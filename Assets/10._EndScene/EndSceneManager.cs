using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
     public TextMeshProUGUI nameTMP;
    [SerializeField] Text scoreText;
    [SerializeField] Text rewardStarText;
    [SerializeField] Text myScoreNameText;
    [SerializeField] Button btn_Exit;

    public string startSceneName = "0.SelectModeScene";
    //highscore일때만 보여주는거
    public GameObject HighScoreImage;
    int bestScore;
    int minScore;
    int middleScore;
    public int rewardStar;


    public InGameRanking inGameRanking;

    private void Start()
    {
        StartCoroutine(CO_ActiveButton());
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().sortingLayerName = "UI";



        minScore = int.Parse(GameDatas.Inst.objectData[3]);
        middleScore = int.Parse(GameDatas.Inst.objectData[4]);


        if (GameDatas.Inst.mode == Mode.COLLABORATION)
        {
            GameManager.Inst.ScoreSet(GameDatas.Inst.score);
            bestScore = GameManager.Inst.bestScore;
            myScoreNameText.text = "최고기록";
            scoreText.text = $"{bestScore}";
            nameTMP.text = $"이번 기록 : {GameDatas.Inst.score}";
            
            if (GameDatas.Inst.score < minScore) rewardStar = 5;
            else if (GameDatas.Inst.score < middleScore) rewardStar = 8;
            else rewardStar = 12;
        }
        else // 개인모드일 때
        {
            myScoreNameText.text = "내점수";
            scoreText.text = $"{GameDatas.Inst.score}";
            if (GameDatas.Inst.score < minScore) rewardStar = 5;
            else if (GameDatas.Inst.score < middleScore) rewardStar = 8;
            else rewardStar = 12;

            nameTMP.text = "불러오는 중...0";

            inGameRanking.EndingSceneSequnce(GameDatas.Inst.score, rewardStar, 0, GameDatas.Inst.difficulty);
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
