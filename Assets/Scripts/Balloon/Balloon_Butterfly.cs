using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Butterfly : Balloon
{
    private void OnEnable()
    {
        //Floating();
    }
    protected override void Update()
    {
        base.Update();
    }
    // ���� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Release(gameObject);

        // �ǹ�Ÿ�� ����
        GameManager.Inst.FeverSpawnerOn();
        
    }

    
}
