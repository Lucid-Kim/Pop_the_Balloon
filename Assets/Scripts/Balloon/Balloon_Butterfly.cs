using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Butterfly : Balloon
{
    
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            DictionaryPool.Inst.Destroy(gameObject);
        }
    }
    // 나비 풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(gameObject);
        GameManager.Inst.FeverSpawnerOn();
        
    }

    
}
