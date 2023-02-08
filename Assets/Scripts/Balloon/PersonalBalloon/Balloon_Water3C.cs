using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon_Water3C : Balloon
{
    TextMeshProUGUI scoreText;
    int addedScore = 20;
    private void Awake()
    {
        scoreText = obj[2].GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Floating();
        
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void Interact()
    {
        base.Interact();
        // 게임매니저에서 관리하는 점수 올리기
        GameManager.Inst.score += addedScore;
        // 물 뿌리는 효과 생성
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(9, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // 점수 올라가는 텍스트 생성
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 2, 0)), Quaternion.identity, GameObject.Find("UI").transform);
        scoreText.text = "+" + addedScore;

        // UI 텍스트 점수 변경
        UIManager.Inst.UpdateScore();
    }
}
