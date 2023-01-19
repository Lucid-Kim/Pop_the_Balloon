using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("슬라이더")]
    [SerializeField] public Slider sunSlider; // 해 슬라이더
    [SerializeField] public Slider waterSlider; // 물 슬라이더
    [SerializeField] public Slider fertilizerSlider; // 비료 슬라이더
    [SerializeField] Image sunSliderImage; // 해 슬라이더를 나타내는 해의 얼굴
    [SerializeField] Sprite smileSun; // 웃는 해의 얼굴(1단계)
    [SerializeField] Sprite wrySun; // 찡그린 해의 얼굴(2단계)
    [SerializeField] Sprite crySun; // 우는 해의 얼굴(3단계)
    
    [Header("게임오버")]
    [SerializeField] GameObject gameoverPanel; // 게임 종료시 나오는 판넬
    [SerializeField] TextMeshProUGUI score; // 점수를 나타내는 텍스트
    [SerializeField] GameObject restartBtn; // 재시작 버튼
    [SerializeField] GameObject rankWindow; // 랭크를 나타내는 창
    Coroutine rankWindowOn; // 랭크를 나타내는 코루틴

    [SerializeField] public TextMeshProUGUI feverText; // 피버타임을 알려주는 텍스트

    
    // 모든 슬라이더가 일정하게 줄어들게 하는 코루틴 (현재 0.5초 당 2퍼센트씩 줄어들게 설정)
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
    // 게임 오버시 실행되는 함수
    public void GameoverOn()
    {
        gameoverPanel.gameObject.SetActive(true);
        UpdateScore();
        rankWindowOn = StartCoroutine(nameof(CO_UpdateScoreRank));
    }

    // 물 슬라이더 조절 함수
    public void UpdateWaterSlider(float value)
    {
        waterSlider.value += value;
    }

    // 해 슬라이더 조절 함수
    public void UpdateSunSlider(float value)
    {
        sunSlider.value += value;
    }

    // 물 슬라이더 조절 함수
    public void UpdateFertilizerSlider(float value)
    {
        fertilizerSlider.value += value;
    }

    // 스코어를 나타내는 함수
    public void UpdateScore()
    {
        score.text = "내 점수 : " + (GameManager.Inst.bloom.Count * 10);
    }

    // 랭크를 나타내는 코루틴
    IEnumerator CO_UpdateScoreRank()
    {
        Debug.Log("3초전");
        yield return new WaitForSeconds(3f);
        Debug.Log("3초후 랭크 나와");
        gameoverPanel.gameObject.SetActive(false);
        restartBtn.SetActive(true);
        rankWindow.SetActive(true);
    }

}
