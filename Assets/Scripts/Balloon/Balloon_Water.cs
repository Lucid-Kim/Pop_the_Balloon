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
        #region 물 오브젝트 위치 선정
        WaterPool.Inst.Get(new Vector2(0,1.4f));
        WaterPool.Inst.Get(new Vector2(2.5f,2.1f));
        WaterPool.Inst.Get(new Vector2(5f,1.4f));
        WaterPool.Inst.Get(new Vector2(7.5f,2.1f));
        WaterPool.Inst.Get(new Vector2(-2.5f,2.1f));
        WaterPool.Inst.Get(new Vector2(-5f,1.4f));
        WaterPool.Inst.Get(new Vector2(-7.5f,2.1f));
        #endregion
    }
}
