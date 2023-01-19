using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Fertilizer : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    // 비료 풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);

        // 비료 슬라이더 15퍼센트 증가
        UIManager.Inst.UpdateFertilizerSlider(0.15f);
    }
}
