using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Butterfly : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }
    // 나비 풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(gameObject);

        // 피버타임 시작
        GameManager.Inst.FeverSpawnerOn();
        
    }

    
}
