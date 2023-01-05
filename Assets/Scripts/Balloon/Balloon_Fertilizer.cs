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
            BalloonFertilizerPool.Inst.Release(gameObject);
        }
    }

    // ��� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        BalloonFertilizerPool.Inst.Release(this.gameObject);
        UIManager.Inst.UpdateFertilizerSlider(0.02f);
    }
}
