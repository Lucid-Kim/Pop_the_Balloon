using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("게임시작")]
    [SerializeField] GameObject timer; // 남은 시간을 나타내는 타이머
    [SerializeField] Animator readyAni; // 준비시간을 나타내는 애니메이션
    [Header("스포너")]
    [SerializeField] GameObject balloonSpawner; // 협동모드 풍선 생성기
    [SerializeField] GameObject personalSpawner; // 개인모드 풍선 생성기
    [SerializeField] GameObject feverSpawner; // 피버타임 생성기
    int region2Count; // 2구역 풍선 갯수
    int region2Max = int.Parse(GameDatas.Inst.objectData[2]); // 2구역 풍선 최대 갯수
    public int bestScore = 0; // 최고점수
    public int score; // 실시간 점수와 최종 점수를 나타내는 변수
    
    public bool isGameover; // 게임 종료를 나타내는 bool 값
    public bool isFeverTime; // 피버타임을 나타내는 bool 값
    


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
    /// 게임 종료시 실행 되는 함수
    /// </summary>
    public void EndGame()
    {
        Debug.Log("게임 끝!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        personalSpawner.SetActive(false);
        GameoverOn();
    }

    /// <summary>
    /// 3초의 준비 시간을 이후에 게임이 시작되게 하는 코루틴
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
    /// 피버 타임 적용 함수
    /// </summary>
    public void FeverSpawnerOn()
    {
        isFeverTime = true;
        feverSpawner.SetActive(true);
        UIManager.Inst.FeverTextActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    /// <summary>
    /// 피버 타임 해제 코루틴
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
    /// 2구역 풍선의 갯수를 추가하는 함수
    /// </summary>
    /// <param name="num"></param>
    public void Region2AddCount(int num)
    {
        region2Count += num;
    }

    /// <summary>
    /// 2구역에 풍선을 생성해도 되는지 파악하는 bool 값
    /// </summary>
    /// <returns></returns>
    public bool Region2Spawned()
    {
        if (region2Count < region2Max) return true;
        else return false;
    }

    /// <summary>
    /// 현재 점수가 최고 점수보다 높으면 최고점수를 바꿔주는 함수
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
    /// 게임 오버시 실행되는 함수
    /// </summary>
    public void GameoverOn()
    {
        GameDatas.Inst.score = score;
        SceneManager.LoadScene("New Scene", LoadSceneMode.Additive);
    }
}
