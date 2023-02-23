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
    [SerializeField] GameObject restartBtn; // ����� ��ư
    
    Coroutine rankWindowOn; // ��ũ�� ��Ÿ���� �ڷ�ƾ

    [Header("����")]
    [SerializeField] TextMeshProUGUI bestScoreText; // �ְ������� ��Ÿ���� �ؽ�Ʈ
    
    string keyName = "BestScore";
    int bestScore = 0;

    [SerializeField] Image feverText; // �ǹ�Ÿ���� �˷��ִ� �ؽ�Ʈ

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
