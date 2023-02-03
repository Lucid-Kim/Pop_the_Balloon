using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Water1 : Balloon
{

    private void OnEnable()
    {
        Floating();
    }

    protected override void Update()
    {
        base.Update();
    }
    // 1구역 물풍선 터치했을 때
    public override void Interact()
    {
        base.Interact();
        
        if (GameManager.Inst.Region2Spawned() == true)
        {
            // 2구역에 물풍선 생성
            DictionaryPool.Inst.Instantiate(obj[1], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
    }
}
