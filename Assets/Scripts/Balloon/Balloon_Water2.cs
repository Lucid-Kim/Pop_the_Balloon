using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Water2 : Balloon
{
    protected override void Update()
    {
        
    }
    public override void Interact()
    {
        base.Interact();
        
        GameManager.Inst.Region2AddCount(-1);
        // 물 뿌리는 효과 생성
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(9, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // 점수 올라가는 텍스트 생성
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 2, 0)), Quaternion.identity, GameObject.Find("UI").transform);

        // 게임매니저에서 관리하는 점수 올리기
        GameManager.Inst.score += 10;

        // UI 텍스트 점수 변경
        UIManager.Inst.UpdateScore();
    }

}
