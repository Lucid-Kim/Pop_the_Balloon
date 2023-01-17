using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Bee : Balloon
{
    [SerializeField] GameObject bee;
    [SerializeField] GameObject blooming;
    float deg;
    
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            DictionaryPool.Inst.Destroy(this.gameObject);
        }
    }

    // ¹ú Ç³¼± Å¬¸¯ÇßÀ» ¶§
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);
        Instantiate(bee, this.gameObject.transform.position, Quaternion.identity);
    }

}
