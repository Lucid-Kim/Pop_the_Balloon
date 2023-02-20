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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Inst == null) Inst = this;
        else Destroy(gameObject);
    }
}