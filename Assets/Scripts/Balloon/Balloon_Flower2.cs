using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower2 : Balloon
{
    protected override void Update()
    {

    }
    public override void Interact()
    {
        base.Interact();
        GameManager.Inst.Region2AddCount(-1);
        // 꽃 생성 (현재는 랜덤생성인데 기획에서 내용 바뀌면 위치 바꿔줘야함)
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        
        // 점수 올라가는 텍스트 생성
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);

        // 게임매니저에서 관리하는 점수 올리기
        GameManager.Inst.score += 10;

        // UI 텍스트 점수 변경
        UIManager.Inst.UpdateScore();
    }
}
