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
    //highscore�϶��� �����ִ°�
    public GameObject HighScoreImage;
    int bestScore;
    int minScore;
    int middleScore;
    public int rewardStar;


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
            myScoreNameText.text = "�ְ���";
            scoreText.text = $"{bestScore}";
            nameTMP.text = $"�̹� ��� : {GameDatas.Inst.score}";
            
            if (GameDatas.Inst.score < minScore) rewardStar = 5;
            else if (GameDatas.Inst.score < middleScore) rewardStar = 8;
            else rewardStar = 12;
        }
        else // ���θ���� ��
        {
            myScoreNameText.text = "������";
            scoreText.text = $"{GameDatas.Inst.score}";
            if (GameDatas.Inst.score < minScore) rewardStar = 5;
            else if (GameDatas.Inst.score < middleScore) rewardStar = 8;
            else rewardStar = 12;

            int dif = 0;

            switch (GameDatas.Inst.difficulty)
            {
                case DIFFICULTY.EASY: dif = 0; break;
                case DIFFICULTY.NORMAL: dif = 1; break;
                case DIFFICULTY.MASTER: dif = 2; break;
                case DIFFICULTY.HARD: dif = 3; break;
            }

            InGameRanking.Inst.SetGameInfo(GameDatas.Inst.id, GameDatas.Inst.score, rewardStar, 0, dif);
            InGameRanking.Inst.SaveScore(GameDatas.Inst.id);

        }




        rewardStarText.text = "X"+rewardStar;
        //reward ���� ���� �Լ��� ���ʿ� �߰�
    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        DictionaryPool.Inst.DestroyMySelp();
        SceneManager.LoadScene(startSceneName);   
    }

    /// <summary>
    /// 5�� �Ŀ� ��ư Ȱ��ȭ�Ǵ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_ActiveButton()
    {
        yield return new WaitForSeconds(5f);
        btn_Exit.interactable = true;
    }
}
