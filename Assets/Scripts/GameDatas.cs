using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DIFFICULTY
{
    EASY,
    NORMAL,
    HARD,
    MASTER
}

public enum Mode
{
    PERSONAL,
    BATTLE,
    COLLABORATION
}

public class GameDatas : MonoBehaviour
{
    public static GameDatas Inst;

    public DIFFICULTY difficulty;
    public Mode mode;
    public int score;
    public string id = null;

    public List<string> dataList = new List<string>();
    public List<string> layerList = new List<string>();
    public string[] objectData = null;
    public string[] layerData = null;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Inst == null) Inst = this;
        else Destroy(gameObject);
    }

}