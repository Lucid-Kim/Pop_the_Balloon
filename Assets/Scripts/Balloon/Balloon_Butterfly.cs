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
            DictionaryPool.Inst.Destroy(gameObject);
        }
    }
    // ���� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(gameObject);
        GameManager.Inst.FeverSpawnerOn();
        
    }

    
}
