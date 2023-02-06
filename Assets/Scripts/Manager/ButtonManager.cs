using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    string selectLevelScene = "1.StartScene"; // 난이도 선택 씬 이름 설정
    string personalScene = "2.PersonalGameScene"; // 개인 모드 씬 이름 설정
    string collaborationScene = "2.CollaborationGameScene"; // 협동 모드 씬 이름 설정
    private void Start()
    {
        //SoundManager.Inst.PlayBGM("StartSceneBGM");

    }
    // 쉬움 버튼 클릭했을 때 씬 전환
    public void Click_Easy()
    {
        Debug.Log("Easy");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        SceneManager.LoadScene(personalScene);
    }
    // 보통 버튼 클릭했을 때 씬 전환
    public void Click_Normal()
    {
        Debug.Log("Normal");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        SceneManager.LoadScene(personalScene);
    }
    // 어려움 버튼 클릭했을 때 씬 전환
    public void Click_Hard()
    {

        Debug.Log("Hard");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        SceneManager.LoadScene(personalScene);
    }
    // 매우 어려움 버튼 클릭했을 때 씬 전환
    public void Click_Master()
    {
        Debug.Log("Master");
        SoundManager.Inst.PlaySFX("ClickSound");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        SceneManager.LoadScene(personalScene);
    }

    public void Click_Personal()
    {
        GameDatas.Inst.mode = Mode.PERSONAL;
        SceneManager.LoadScene(selectLevelScene);
    }

    public void Click_Battle()
    {
        GameDatas.Inst.mode = Mode.BATTLE;
        SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Collaboration()
    {
        GameDatas.Inst.mode = Mode.COLLABORATION;
        SceneManager.LoadScene(collaborationScene);
    }
}
