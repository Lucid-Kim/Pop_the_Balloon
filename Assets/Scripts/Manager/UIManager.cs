using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("슬라이더")]
    [SerializeField] public Slider sunSlider;
    [SerializeField] public Slider waterSlider;
    [SerializeField] public Slider fertilizerSlider;
    [SerializeField] Image sunSliderImage;
    [SerializeField] Sprite smileSun;
    [SerializeField] Sprite wrySun;
    [SerializeField] Sprite crySun;
    
    [Header("게임오버")]
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject restartBtn;
    [SerializeField] GameObject rankWindow;

    Coroutine rankWindowOn;
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
    public void GameoverOn()
    {
        gameoverPanel.gameObject.SetActive(true);
        UpdateScore();
        rankWindowOn = StartCoroutine(nameof(CO_UpdateScoreRank));
    }

    public void UpdateWaterSlider(float value)
    {
        waterSlider.value += value;
    }

    public void UpdateSunSlider(float value)
    {
        sunSlider.value += value;
    }

    public void UpdateFertilizerSlider(float value)
    {
        fertilizerSlider.value += value;
    }
    public void UpdateScore()
    {
        score.text = "내 점수 : " + (GameManager.Inst.bloom.Count * 10);
    }

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
