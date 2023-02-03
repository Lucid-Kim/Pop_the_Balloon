using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower1 : Balloon
{
    private void OnEnable()
    {
        Floating();
    }

    protected override void Update()
    {
        base.Update();
    }
    // 1备开 采浅急 磐摹沁阑 锭
    public override void Interact()
    {
        base.Interact();
        if (GameManager.Inst.Region2Spawned() == true)
        {
            // 2备开俊 采浅急 积己
            DictionaryPool.Inst.Instantiate(obj[1], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
    }
}
