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
        SoundManager.Inst.PlayBGM("SelectModeBGM");
    }
    // 쉬움 버튼 클릭했을 때 씬 전환
    public void Click_Easy()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[0].Split(","); // 쉬움 난이도 데이터
        SceneManager.LoadScene(personalScene);
    }
    // 보통 버튼 클릭했을 때 씬 전환
    public void Click_Normal()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[1].Split(","); // 보통 난이도 데이터
        SceneManager.LoadScene(personalScene);
    }
    // 어려움 버튼 클릭했을 때 씬 전환
    public void Click_Hard()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[2].Split(","); // 어려움 난이도 데이터
        SceneManager.LoadScene(personalScene);
    }
    // 매우 어려움 버튼 클릭했을 때 씬 전환
    public void Click_Master()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[3].Split(","); // 매우 어려움 난이도 데이터
        SceneManager.LoadScene(personalScene);
    }

    public void Click_Personal()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.mode = Mode.PERSONAL;
        GameDatas.Inst.dataList = CSVLoad.LoadData("PersonalData.csv");
        GameDatas.Inst.layerList = CSVLoad.LoadData("LayerData.csv");
        GameDatas.Inst.layerData = GameDatas.Inst.layerList[0].Split(",");
        SceneManager.LoadScene(selectLevelScene);
    }

    public void Click_Collaboration()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.mode = Mode.COLLABORATION;
        GameDatas.Inst.dataList = CSVLoad.LoadData("CollaborationData.csv");
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[0].Split(","); // 협동모드 데이터
        SceneManager.LoadScene(collaborationScene);
    }
}
