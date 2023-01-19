using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Bee : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    // ¹ú Ç³¼± Å¬¸¯ÇßÀ» ¶§ 
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);
        // ¹ú ¿ÀºêÁ§Æ® »ý¼º
        DictionaryPool.Inst.Instantiate(obj[0], this.gameObject.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);
        
    }

}
