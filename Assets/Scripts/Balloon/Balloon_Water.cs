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
    // ��ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        BalloonWaterPool.Inst.Release(this.gameObject);
        UIManager.Inst.UpdateWaterSlider(0.02f);
        #region �� ������Ʈ ��ġ ����
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
