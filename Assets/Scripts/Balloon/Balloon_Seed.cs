using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Seed : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    // ¾¾¾Ñ Ç³¼± Å¬¸¯ÇßÀ» ¶§
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(1.0f, 8.0f); // ¿À¸¥ÂÊÀ» ³ªÅ¸³»´Â xÁÂÇ¥
        ranNum = Random.Range(0, 2);
        DictionaryPool.Inst.Destroy(gameObject);

        // ²É Ç³¼± 1,2 Áß¿¡ ·£´ýÀ¸·Î »ý¼º
        DictionaryPool.Inst.Instantiate(obj[ranNum], new Vector2(ranX, -4), Quaternion.identity, DictionaryPool.Inst.transform); 

        // ¾¾¾Ñ Ç³¼± È¿°ú »ý¼º
        DictionaryPool.Inst.Instantiate(obj[2], gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
    }
}
