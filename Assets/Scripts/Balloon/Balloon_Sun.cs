using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Sun : Balloon
{
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonSunPool.Inst.Release(gameObject);
        }
    }

    // 해풍선 클릭시 구현해야하는 것들 입력할 곳
    public override void Interact()
    {
        base.Interact();
        BalloonSunPool.Inst.Release(this.gameObject);
        UIManager.Inst.UpdateSunSlider(0.05f);
        UIManager.Inst.SunEffect();
        
    }
}
