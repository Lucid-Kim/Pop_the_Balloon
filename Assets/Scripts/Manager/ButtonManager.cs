using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    string selectLevelScene = "1.StartScene"; // ���̵� ���� �� �̸� ����
    string personalScene = "2.PersonalGameScene"; // ���� ��� �� �̸� ����
    string collaborationScene = "2.CollaborationGameScene"; // ���� ��� �� �̸� ����
    private void Start()
    {
        SoundManager.Inst.PlayBGM("SelectModeBGM");
    }
    // ���� ��ư Ŭ������ �� �� ��ȯ
    public void Click_Easy()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[0].Split(","); // ���� ���̵� ������
        SceneManager.LoadScene(personalScene);
    }
    // ���� ��ư Ŭ������ �� �� ��ȯ
    public void Click_Normal()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[1].Split(","); // ���� ���̵� ������
        SceneManager.LoadScene(personalScene);
    }
    // ����� ��ư Ŭ������ �� �� ��ȯ
    public void Click_Hard()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[2].Split(","); // ����� ���̵� ������
        SceneManager.LoadScene(personalScene);
    }
    // �ſ� ����� ��ư Ŭ������ �� �� ��ȯ
    public void Click_Master()
    {
        SoundManager.Inst.PlaySFX("SFX_ClickBtn");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[3].Split(","); // �ſ� ����� ���̵� ������
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
        GameDatas.Inst.objectData = GameDatas.Inst.dataList[0].Split(","); // ������� ������
        SceneManager.LoadScene(collaborationScene);
    }
}
