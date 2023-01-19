using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    private void Start()
    {
        //SoundManager.Inst.PlayBGM("StartSceneBGM");

    }
    // 쉬움 버튼 클릭했을 때 씬 전환
    public void Click_Easy()
    {
        Debug.Log("Easy");
        
        SceneManager.LoadScene("2.GameScene");
    }
    // 보통 버튼 클릭했을 때 씬 전환
    public void Click_Normal()
    {
        Debug.Log("Normal");
        SoundManager.Inst.PlaySFX("ClickSound");
        
        SceneManager.LoadScene("2.GameScene");
    }
    // 어려움 버튼 클릭했을 때 씬 전환
    public void Click_Hard()
    {

        Debug.Log("Hard");
        SoundManager.Inst.PlaySFX("ClickSound");
        
        SceneManager.LoadScene("2.GameScene");
    }
    // 매우 어려움 버튼 클릭했을 때 씬 전환
    public void Click_Master()
    {
        Debug.Log("Master");
        SoundManager.Inst.PlaySFX("ClickSound");
        
        SceneManager.LoadScene("2.GameScene");
    }
}