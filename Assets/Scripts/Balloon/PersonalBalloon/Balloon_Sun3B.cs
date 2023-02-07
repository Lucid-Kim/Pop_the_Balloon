using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balloon_Sun3B : Balloon
{
    TextMeshProUGUI scoreText;
    int addedScore = 15;
    private void Awake()
    {
        scoreText = obj[2].GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Floating();
        UpdateSpeed(6f);
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void Interact()
    {
        base.Interact();
        GameManager.Inst.Region2AddCount(-1);
        // 게임매니저에서 관리하는 점수 올리기
        GameManager.Inst.score += addedScore;
        // 해 빛 효과 생성
        GameObject sunLight = DictionaryPool.Inst.Instantiate(obj[1], new Vector3(-6, 11, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        sunLight.transform.rotation = Quaternion.Euler(68.9f, 113, 90);

        // 점수 올라가는 텍스트 생성
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);
        scoreText.text = "+" + addedScore;

        // UI 텍스트 점수 변경
        UIManager.Inst.UpdateScore();
    }
}
