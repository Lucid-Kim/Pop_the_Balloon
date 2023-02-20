using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("�ΰ���")]
    [SerializeField] TextMeshProUGUI ingameScore; // �ΰ��� �ȿ��� ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] TextMeshProUGUI addedScore;  // ǳ���� ��ġ���� �� ������ �ؽ�Ʈ
    
    [Header("���ӿ���")]
    [SerializeField] TextMeshProUGUI gameoverScore; // ���� ����� ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] TextMeshProUGUI gameoverBestScore; // ���� ����� �ְ� ������ ��Ÿ���� �ؽ�Ʈ
    [SerializeField] GameObject restartBtn; // ����� ��ư
    
    Coroutine rankWindowOn; // ��ũ�� ��Ÿ���� �ڷ�ƾ

    [Header("����")]
    [SerializeField] TextMeshProUGUI bestScoreText; // �ְ������� ��Ÿ���� �ؽ�Ʈ
    
    string keyName = "BestScore";
    int bestScore = 0;

    [SerializeField] TextMeshProUGUI feverText; // �ǹ�Ÿ���� �˷��ִ� �ؽ�Ʈ

    /// <summary>
    /// �ΰ��ӿ��� ���ھ ��Ÿ���� �Լ�
    /// </summary>
    public void UpdateScore()
    {
        ingameScore.text = GameManager.Inst.score.ToString();
    }
    

    public void FeverTextActive(bool isOn = true)
    {
        feverText.gameObject.SetActive(isOn);
    }

    
    


}
