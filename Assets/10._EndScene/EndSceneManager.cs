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
    //highscore�϶��� �����ִ°�
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
            myScoreNameText.text = "�ְ���";
            scoreText.text = $"{bestScore}";
            nameTMP.text = $"�̹� ��� : {GameDatas.Inst.score}";
        }
        else
        {
            myScoreNameText.text = "������";
            scoreText.text = $"{GameDatas.Inst.score}";
            nameTMP.text = "���̵� ���Ͷ�";
        }
        
        
        //�̸��ٲ������
        //nameTMP.text = GameData.Inst.;
        //HighScore�϶� ó�� �ؾ���
        bool isHighScore = false;
        HighScoreImage.SetActive(isHighScore);


        //���� ������ ���⼭ 
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
        //reward ���� ���� �Լ��� ���ʿ� �߰�
    }

    public void ExitRoom()
    {
        Time.timeScale = 1;
        DictionaryPool.Inst.DestroyMySelp();
        SceneManager.LoadScene(startSceneName);   
    }


}
