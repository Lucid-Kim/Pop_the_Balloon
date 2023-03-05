using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputID : MonoBehaviour
{

    public TextMeshProUGUI id = null;


    public void OnClick_Confirm()
    {
        GameDatas.Inst.id = id.text;
        SceneManager.LoadScene("0.SelectModeScene");

    }

}
