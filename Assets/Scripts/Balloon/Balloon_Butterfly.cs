using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Butterfly : Balloon
{
    
    void Update()
    {
        Floating();
        if (transform.position.y >= 6)
        {
            BalloonButterflyPool.Inst.Release(gameObject);
        }
    }
    // ���� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        BalloonButterflyPool.Inst.Release(gameObject);
        GameManager.Inst.FeverSpawnerOn();
        
    }

    
}
