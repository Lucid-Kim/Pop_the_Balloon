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

    // ��ǳ�� Ŭ���� �����ؾ��ϴ� �͵� �Է��� ��
    public override void Interact()
    {
        base.Interact();
        BalloonSunPool.Inst.Release(this.gameObject);
        UIManager.Inst.UpdateSunSlider(0.05f);
        UIManager.Inst.SunEffect();
        
    }
}
