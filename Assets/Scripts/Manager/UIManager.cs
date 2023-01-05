using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Header("�����̴�")]
    [SerializeField] public Slider sunSlider;
    [SerializeField] public Slider waterSlider;
    [SerializeField] public Slider fertilizerSlider;
    [SerializeField] Image sunSliderImage;
    [SerializeField] Sprite smileSun;
    [SerializeField] Sprite crySun;
    [Header("����Ʈ")]
    [SerializeField] Image sunShine;
    [SerializeField] Image sunImage;
    [Header("���ӿ���")]
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] TextMeshProUGUI flowerCount;
    [SerializeField] TextMeshProUGUI witheredFlowerCount;
    
    public IEnumerator CO_ReduceSlider()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            sunSlider.value -= 0.02f;
            waterSlider.value -= 0.02f;
            fertilizerSlider.value -= 0.02f;
            #region �����̴� 60�ۼ�Ʈ ������ �� ���� �̹��� ����
            if (sunSlider.value <= 0.6f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.red;
                sunSliderImage.sprite = crySun;
            }
            else
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.green;
                sunSliderImage.sprite = smileSun;
            }
            if (waterSlider.value <= 0.6f)
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.red;
            }
            else
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.green;
            }
            if (fertilizerSlider.value <= 0.6f)
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.red;
            }
            else
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.green;
            }
            #endregion
            if (GameManager.Inst.isGameover == true) break;
        }
    }
    public void GameoverOn()
    {
        gameoverPanel.gameObject.SetActive(true);
        UpdateFlowerCount();
        UpdateWitheredFlowerCount();
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
    public void UpdateFlowerCount()
    {
        flowerCount.text = "�� : " + GameManager.Inst.bloom.Count;
    }

    public void UpdateWitheredFlowerCount()
    {
        witheredFlowerCount.text = "�õ� �� : " + GameManager.Inst.witheredFlowerQueue.Count;
    }
    public void SunEffect()
    {
        sunShine.gameObject.SetActive(true);
        sunImage.gameObject.SetActive(true);
        
    }

}
