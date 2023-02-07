using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("인게임")]
    [SerializeField] public Slider sunSlider; // 해 슬라이더
    [SerializeField] public Slider waterSlider; // 물 슬라이더
    [SerializeField] public Slider fertilizerSlider; // 비료 슬라이더
    [SerializeField] Image sunSliderImage; // 해 슬라이더를 나타내는 해의 얼굴
    [SerializeField] Sprite smileSun; // 웃는 해의 얼굴(1단계)
    [SerializeField] Sprite wrySun; // 찡그린 해의 얼굴(2단계)
    [SerializeField] Sprite crySun; // 우는 해의 얼굴(3단계)
    [SerializeField] TextMeshProUGUI ingameScore; // 인게임 안에서 점수를 나타내는 텍스트
    
    [Header("게임오버")]
    [SerializeField] GameObject gameoverPanel; // 게임 종료시 나오는 판넬
    [SerializeField] TextMeshProUGUI gameoverScore; // 게임 종료시 점수를 나타내는 텍스트
    [SerializeField] GameObject restartBtn; // 재시작 버튼
    [SerializeField] GameObject rankWindow; // 랭크를 나타내는 창
    Coroutine rankWindowOn; // 랭크를 나타내는 코루틴

    [Header("점수")]
    [SerializeField] TextMeshProUGUI bestScoreText; // 최고점수를 나타내는 텍스트
    [SerializeField] int rankNum; // 점수의 등수
    [SerializeField] GameObject rankInfo; // 랭크를 나타내는 정보 프리팹
    [SerializeField] ScrollRect rankScrollview;
    string keyName = "BestScore";
    List<int> bestScore = new List<int>(); // 최고점수
    int tmpScore = 0; // 임시 점수

    [SerializeField] TextMeshProUGUI feverText; // 피버타임을 알려주는 텍스트

    private void Awake()
    {
        //bestScoreText = rankInfo.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //rankNum = rankInfo.transform.GetChild(0).gameObject
    }

    /// <summary>
    /// 모든 슬라이더가 일정하게 줄어들게 하는 코루틴 (현재 0.5초 당 2퍼센트씩 줄어들게 설정)
    /// </summary>
    /// <returns></returns>
    public IEnumerator CO_ReduceSlider()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (GameManager.Inst.isFeverTime == false)
            {
                sunSlider.value -= 0.02f;
                waterSlider.value -= 0.02f;
                fertilizerSlider.value -= 0.02f;
            }
            #region 슬라이더 퍼센트마다 색과 이미지 변경
            if (sunSlider.value < 0.3f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // 빨간색으로 변경
                sunSliderImage.sprite = crySun;
            }
            else if (sunSlider.value < 0.6f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102 / 255f, 0); // 주황색으로 변경
                sunSliderImage.sprite = wrySun;
            }
            else
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 206 / 255f, 0); // 노란색으로 변경
                sunSliderImage.sprite = smileSun;
            }
            #endregion

            #region 물 슬라이더 퍼센트마다 색과 이미지 변경
            if (waterSlider.value < 0.3f)
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // 빨간색으로 변경
            }
            else if (waterSlider.value < 0.6f)
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102 / 255f, 0); // 주황색으로 변경
            }
            else
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 206 / 255f, 0); // 노란색으로 변경
            }
            #endregion

            #region 비료 슬라이더 퍼센트마다 색과 이미지 변경

            if (waterSlider.value < 0.3f)
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // 빨간색으로 변경
            }
            else if (fertilizerSlider.value < 0.6f)
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102 / 255f, 0); // 주황색으로 변경
            }
            else
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 206 / 255f, 0); // 노란색으로 변경
            }
            #endregion
            if (GameManager.Inst.isGameover == true) break;
        }
    }
    /// <summary>
    /// 게임 오버시 실행되는 함수
    /// </summary>
    public void GameoverOn()
    {
        gameoverPanel.gameObject.SetActive(true);
        GameoverScore();
        rankWindowOn = StartCoroutine(nameof(CO_UpdateScoreRank));
    }

    /// <summary>
    /// 물 슬라이더 조절 함수
    /// </summary>
    /// <param name="value"></param>
    public void UpdateWaterSlider(float value)
    {
        waterSlider.value += value;
    }

    /// <summary>
    /// 해 슬라이더 조절 함수
    /// </summary>
    /// <param name="value"></param>
    public void UpdateSunSlider(float value)
    {
        sunSlider.value += value;
    }

    /// <summary>
    /// 물 슬라이더 조절 함수
    /// </summary>
    /// <param name="value"></param>
    public void UpdateFertilizerSlider(float value)
    {
        fertilizerSlider.value += value;
    }

    /// <summary>
    /// 게임 종료시 스코어를 나타내는 함수
    /// </summary>
    public void GameoverScore()
    {
        ScoreSet(GameManager.Inst.score);
        gameoverScore.text = "내 점수 : " + GameManager.Inst.score;
    }

    /// <summary>
    /// 인게임에서 스코어를 나타내는 함수
    /// </summary>
    public void UpdateScore()
    {
        ingameScore.text = "점수 : " + GameManager.Inst.score;
    }
    /// <summary>
    /// 랭크를 나타내는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_UpdateScoreRank()
    {
        Debug.Log("3초전");
        yield return new WaitForSeconds(3f);
        Debug.Log("3초후 랭크 나와");
        SceneManager.LoadScene("RankScene");
        //gameoverPanel.gameObject.SetActive(false);
        //restartBtn.SetActive(true);
        //rankWindow.SetActive(true);
    }

    public void FeverTextActive(bool isOn)
    {
        feverText.gameObject.SetActive(isOn);
    }

    /// <summary>
    /// 현재 점수를 저장하는 함수
    /// </summary>
    /// <param name="curScore"></param>
    public void ScoreSet(int curScore)
    {
        PlayerPrefs.SetInt("CurScore", curScore); // 현재점수 저장

        for (int i = 0; i < bestScore.Count; i++)
        {
            // 저장된 최고 점수 가져오기
            bestScore[i] = PlayerPrefs.GetInt(i + keyName);

            // 현재 점수가 랭킹에 오를 수 있다면
            while (bestScore[i] < curScore)
            {
                // 자리 바꾸기
                tmpScore = bestScore[i];
                bestScore[i] = curScore;

                // 현재 점수 랭킹에 저장
                PlayerPrefs.SetInt(i + keyName, curScore);

                // 다음 점수를 확인을 반복하기 위한 점수 변경
                curScore = tmpScore;
            }
        }

        // 랭킹에 맞게 점수 저장
        for (int i = 0; i < bestScore.Count; i++)
        {
            PlayerPrefs.SetInt(i + keyName, bestScore[i]);
        }
    }

    public void ShowScore()
    {
        for (int i = 0; i < bestScore.Count; i++)
        {
            Instantiate(rankInfo, rankScrollview.content);
            rankInfo.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i + 1 + " 등";
            rankInfo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = bestScore[i].ToString();
        }

    }



}
