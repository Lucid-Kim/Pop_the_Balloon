using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon_Flower3C : Balloon
{
    TextMeshProUGUI scoreText;
    int addedScore = 20;
    
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

        // 꽃 생성 (현재는 랜덤생성인데 기획에서 내용 바뀌면 위치 바꿔줘야함)
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // 점수 올라가는 텍스트 생성
        GameObject temp = DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);
        scoreText = temp.GetComponent<TextMeshProUGUI>();
        scoreText.text = "+" + addedScore;
        //UIManager.Inst.AddedScore(cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), addedScore);
        // UI 텍스트 점수 변경
        UIManager.Inst.UpdateScore();
    }
}
