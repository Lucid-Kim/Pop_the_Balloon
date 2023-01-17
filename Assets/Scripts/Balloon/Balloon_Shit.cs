using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Shit : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            DictionaryPool.Inst.Destroy(gameObject);
        }
    }
    // ¶Ë Ç³¼± Å¬¸¯ÇßÀ» ¶§
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(-8.0f, -1f);
        DictionaryPool.Inst.Instantiate(obj[0], new Vector2(ranX, -4), Quaternion.identity, DictionaryPool.Inst.transform); // ¶Ë Ç³¼± ÅÍÄ¡½Ã ºñ·á Ç³¼± »ý¼º
        DictionaryPool.Inst.Instantiate(obj[1], this.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); // Ç³¼± À§Ä¡¿¡ È¿°ú Ãâ·Â
        DictionaryPool.Inst.Destroy(this.gameObject);
    }
}
