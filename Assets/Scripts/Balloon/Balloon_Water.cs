using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Water : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonWaterPool.Inst.Release(gameObject);
        }
    }
    // 물풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        BalloonWaterPool.Inst.Release(this.gameObject);
        UIManager.Inst.UpdateWaterSlider(0.02f);
        WaterPool.Inst.Get(gameObject.transform.position + new Vector3(0,2,0));
        HosePool.Inst.Get(new Vector3(9, -4, 0));
    }
}
