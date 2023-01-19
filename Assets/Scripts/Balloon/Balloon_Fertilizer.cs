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

    // ��� ǳ�� Ŭ������ ��
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject);

        // ��� �����̴� 15�ۼ�Ʈ ����
        UIManager.Inst.UpdateFertilizerSlider(0.15f);
    }
}
