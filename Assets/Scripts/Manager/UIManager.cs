using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("�ΰ���")]
    [SerializeField] public Slider sunSlider; // �� �����̴�
    [SerializeField] public Slider waterSlider; // �� �����̴�
    [SerializeField] public Slider fertilizerSlider; // ��� �����̴�
    [SerializeField] Image sunSliderImage; // �� �����̴��� ��Ÿ���� ���� ��
    [SerializeField] Sprite smileSun; // ���� ���� ��(1�ܰ�)
    [SerializeField] Sprite wrySun; // ���׸� ���� ��(2�ܰ�)
    [SerializeField] Sprite crySun; // ��� ���� ��(3�ܰ�)
    [SerializeField] TextMeshProUGUI ingameScore; // �ΰ��� �ȿ��� ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] TextMeshProUGUI addedScore;  // ǳ���� ��ġ���� �� ������ �ؽ�Ʈ
    
    [Header("���ӿ���")]
    [SerializeField] GameObject gameoverPanel; // ���� ����� ������ �ǳ�
    [SerializeField] TextMeshProUGUI gameoverScore; // ���� ����� ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] TextMeshProUGUI gameoverBestScore; // ���� ����� �ְ� ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] GameObject restartBtn; // ����� ��ư
    [SerializeField] GameObject rankWindow; // ��ũ�� ��Ÿ���� â
    Coroutine rankWindowOn; // ��ũ�� ��Ÿ���� �ڷ�ƾ

    [Header("����")]
    [SerializeField] TextMeshProUGUI bestScoreText; // �ְ������� ��Ÿ���� �ؽ�Ʈ
    [SerializeField] int rankNum; // ������ ���
    [SerializeField] GameObject rankInfo; // ��ũ�� ��Ÿ���� ���� ������
    [SerializeField] ScrollRect rankScrollview;
    string keyName = "BestScore";
    int bestScore = 0;

    [SerializeField] TextMeshProUGUI feverText; // �ǹ�Ÿ���� �˷��ִ� �ؽ�Ʈ

    private void Awake()
    {
        //bestScoreText = rankInfo.transform.GetChild(1).gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //rankNum = rankInfo.transform.GetChild(0).gameObject
    }

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
        GameoverScore();
        
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
    /// ���� ����� ���ھ ��Ÿ���� �Լ�
    /// </summary>
    public void GameoverScore()
    {
        if (GameDatas.Inst.mode == Mode.COLLABORATION)
        {
            ScoreSet(GameManager.Inst.score);
            gameoverBestScore.text = $"�ְ� ��� : {bestScore}";
        }
        gameoverScore.text = $"�̹� ��� : {GameManager.Inst.score}";
    }

    /// <summary>
    /// �ΰ��ӿ��� ���ھ ��Ÿ���� �Լ�
    /// </summary>
    public void UpdateScore()
    {
        ingameScore.text = $"���� : {GameManager.Inst.score}";
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

        //restartBtn.SetActive(true);
        //rankWindow.SetActive(true);
    }

    public void FeverTextActive(bool isOn = true)
    {
        feverText.gameObject.SetActive(isOn);
    }

    /// <summary>
    /// ���� ������ �ְ� �������� ������ �ְ������� �ٲ��ִ� �Լ�
    /// </summary>
    /// <param name="curScore"></param>
    public void ScoreSet(int curScore)
    {
        bestScore = PlayerPrefs.GetInt("BestScore");

        if (curScore > bestScore)
        {
            bestScore = curScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    


}
