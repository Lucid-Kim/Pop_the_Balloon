using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("���ӽ���")]
    [SerializeField] GameObject timer; // ���� �ð��� ��Ÿ���� Ÿ�̸�
    [SerializeField] Animator readyAni; // �غ�ð��� ��Ÿ���� �ִϸ��̼�
    [Header("������")]
    [SerializeField] GameObject balloonSpawner; // ������� ǳ�� ������
    [SerializeField] GameObject personalSpawner; // ���θ�� ǳ�� ������
    [SerializeField] GameObject feverSpawner; // �ǹ�Ÿ�� ������
    int region2Count; // 2���� ǳ�� ����
    int bestScore = 0; // �ְ�����
    public List<GameObject> bloom = new List<GameObject>(); // ���ھ� ������ ���� �Ǿ��ִ� �� ����Ʈ
    public int score; // �ǽð� ������ ���� ������ ��Ÿ���� ����
    
    public bool isGameover; // ���� ���Ḧ ��Ÿ���� bool ��
    public bool isFeverTime; // �ǹ�Ÿ���� ��Ÿ���� bool ��
    Coroutine withered; // ���� �õ�� ����� �ڷ�ƾ ����


    private void OnEnable()
    {
        readyAni.SetTrigger("Start");
        StartCoroutine(nameof(CO_ReadyOff));

        switch (GameDatas.Inst.mode)
        {
            case Mode.COLLABORATION:
                SoundManager.Inst.PlayBGM("CollaborationBGM");
                break;
            case Mode.PERSONAL:
                SoundManager.Inst.PlayBGM("PersonalBGM");
                break;
        }
    }

    /// <summary>
    /// ���� ����� ���� �Ǵ� �Լ�
    /// </summary>
    public void EndGame()
    {
        Debug.Log("���� ��!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        personalSpawner.SetActive(false);
        GameoverOn();
    }

    /// <summary>
    /// 3���� �غ� �ð��� ���Ŀ� ������ ���۵ǰ� �ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_ReadyOff()
    {
        yield return new WaitForSeconds(4f);
        timer.SetActive(true);

        switch (GameDatas.Inst.mode)
        {
            case Mode.PERSONAL:
                personalSpawner.SetActive(true);
                break;
            case Mode.COLLABORATION:
                balloonSpawner.SetActive(true);
                break;
        }
    }


    /// <summary>
    /// �ǹ� Ÿ�� ���� �Լ�
    /// </summary>
    public void FeverSpawnerOn()
    {
        isFeverTime = true;
        feverSpawner.SetActive(true);
        UIManager.Inst.FeverTextActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    /// <summary>
    /// �ǹ� Ÿ�� ���� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Inst.FeverTextActive(false);
        feverSpawner.SetActive(false);
        isFeverTime = false;
    }

    /// <summary>
    /// �Ǿ��ִ� �� ����Ʈ���� ���� ���� �� ���� �������� �Լ�
    /// </summary>
    /// <returns></returns>
    public GameObject ListDequeue()
    {
        GameObject selectObj = bloom[0];
        bloom.RemoveAt(0);
        return selectObj;
    }

    /// <summary>
    /// 2���� ǳ���� ������ �߰��ϴ� �Լ�
    /// </summary>
    /// <param name="num"></param>
    public void Region2AddCount(int num)
    {
        region2Count += num;
    }

    /// <summary>
    /// 2������ ǳ���� �����ص� �Ǵ��� �ľ��ϴ� bool ��
    /// </summary>
    /// <returns></returns>
    public bool Region2Spawned()
    {
        if (region2Count < 8) return true;
        else return false;
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


    /// <summary>
    /// ���� ������ ����Ǵ� �Լ�
    /// </summary>
    public void GameoverOn()
    {
        GameDatas.Inst.score = score;
        SceneManager.LoadScene("Additive_EndScene", LoadSceneMode.Additive);
    }
}
