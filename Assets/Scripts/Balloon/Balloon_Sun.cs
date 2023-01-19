using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Sun : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    // 해풍선 클릭시 구현해야하는 것들 입력할 곳
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Release(this.gameObject);

        // 해 슬라이더 15퍼센트 증가
        UIManager.Inst.UpdateSunSlider(0.15f);

        // 해 풍선 터치이펙트 생성
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // 해 빛 효과 생성
        GameObject sunLight = DictionaryPool.Inst.Instantiate(obj[1], new Vector3(-6, 11, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
        sunLight.transform.rotation = Quaternion.Euler(68.9f, 113, 90);
    }
}
