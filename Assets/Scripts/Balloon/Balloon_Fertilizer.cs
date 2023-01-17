using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Fertilizer : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            DictionaryPool.Inst.Destroy(gameObject);
        }
    }

    // 비료 풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);
        UIManager.Inst.UpdateFertilizerSlider(0.15f);
    }
}
