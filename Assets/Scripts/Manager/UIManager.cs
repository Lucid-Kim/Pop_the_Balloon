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
    [SerializeField] Sprite wrySun;
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
            #region �����̴� �ۼ�Ʈ���� ���� �̹��� ����
            if (sunSlider.value < 0.3f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // ���������� ����
                sunSliderImage.sprite = crySun;
            }
            else if (sunSlider.value < 0.6f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255/255f, 102/255f, 0); // ��Ȳ������ ����
                sunSliderImage.sprite = wrySun;
            }
            else
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 206 / 255f, 0); // ��������� ����
                sunSliderImage.sprite = smileSun;
            }
            #endregion


            #region �� �����̴� �ۼ�Ʈ���� ���� �̹��� ����
            if (waterSlider.value < 0.3f)
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255/255f, 0, 0); // ���������� ����
            }
            else if (waterSlider.value < 0.6f)
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102/255f, 0); // ��Ȳ������ ����
            }
            else
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 206 / 255f, 0); // ��������� ����
            }
            #endregion

            #region ��� �����̴� �ۼ�Ʈ���� ���� �̹��� ����

            if (waterSlider.value < 0.3f)
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // ���������� ����
            }
            else if (fertilizerSlider.value < 0.6f)
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102 / 255f, 0); // ��Ȳ������ ����
            }
            else
            {
                fertilizerSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 206 / 255f, 0); // ��������� ����
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
