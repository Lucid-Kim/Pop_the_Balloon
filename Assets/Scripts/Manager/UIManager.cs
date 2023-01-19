using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("�����̴�")]
    [SerializeField] public Slider sunSlider; // �� �����̴�
    [SerializeField] public Slider waterSlider; // �� �����̴�
    [SerializeField] public Slider fertilizerSlider; // ��� �����̴�
    [SerializeField] Image sunSliderImage; // �� �����̴��� ��Ÿ���� ���� ��
    [SerializeField] Sprite smileSun; // ���� ���� ��(1�ܰ�)
    [SerializeField] Sprite wrySun; // ���׸� ���� ��(2�ܰ�)
    [SerializeField] Sprite crySun; // ��� ���� ��(3�ܰ�)
    
    [Header("���ӿ���")]
    [SerializeField] GameObject gameoverPanel; // ���� ����� ������ �ǳ�
    [SerializeField] TextMeshProUGUI score; // ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] GameObject restartBtn; // ����� ��ư
    [SerializeField] GameObject rankWindow; // ��ũ�� ��Ÿ���� â
    Coroutine rankWindowOn; // ��ũ�� ��Ÿ���� �ڷ�ƾ

    [SerializeField] public TextMeshProUGUI feverText; // �ǹ�Ÿ���� �˷��ִ� �ؽ�Ʈ


    /// <summary>
    /// ��� �����̴��� �����ϰ� �پ��� �ϴ� �ڷ�ƾ (���� 0.5�� �� 2�ۼ�Ʈ�� �پ��� ����)
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
            #region �����̴� �ۼ�Ʈ���� ���� �̹��� ����
            if (sunSlider.value < 0.3f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // ���������� ����
                sunSliderImage.sprite = crySun;
            }
            else if (sunSlider.value < 0.6f)
            {
                sunSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102 / 255f, 0); // ��Ȳ������ ����
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
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 0, 0); // ���������� ����
            }
            else if (waterSlider.value < 0.6f)
            {
                waterSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 102 / 255f, 0); // ��Ȳ������ ����
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
    /// <summary>
    /// ���� ������ ����Ǵ� �Լ�
    /// </summary>
    public void GameoverOn()
    {
        gameoverPanel.gameObject.SetActive(true);
        UpdateScore();
        rankWindowOn = StartCoroutine(nameof(CO_UpdateScoreRank));
    }

    /// <summary>
    /// �� �����̴� ���� �Լ�
    /// </summary>
    /// <param name="value"></param>
    public void UpdateWaterSlider(float value)
    {
        waterSlider.value += value;
    }

    /// <summary>
    /// �� �����̴� ���� �Լ�
    /// </summary>
    /// <param name="value"></param>
    public void UpdateSunSlider(float value)
    {
        sunSlider.value += value;
    }

    /// <summary>
    /// �� �����̴� ���� �Լ�
    /// </summary>
    /// <param name="value"></param>
    public void UpdateFertilizerSlider(float value)
    {
        fertilizerSlider.value += value;
    }

    /// <summary>
    /// ���ھ ��Ÿ���� �Լ�
    /// </summary>
    public void UpdateScore()
    {
        score.text = "�� ���� : " + (GameManager.Inst.bloom.Count * 10);
    }

    /// <summary>
    /// ��ũ�� ��Ÿ���� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_UpdateScoreRank()
    {
        Debug.Log("3����");
        yield return new WaitForSeconds(3f);
        Debug.Log("3���� ��ũ ����");
        gameoverPanel.gameObject.SetActive(false);
        restartBtn.SetActive(true);
        rankWindow.SetActive(true);
    }

}
