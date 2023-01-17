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
            DictionaryPool.Inst.Destroy(this.gameObject); // 해당 풍선 지워주기
        }
    }
    // 물풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        DictionaryPool.Inst.Destroy(this.gameObject); // 해당 풍선 지워주기
        UIManager.Inst.UpdateWaterSlider(0.15f);
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); // 물 오브젝트 생성
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(9, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform); // 물 호스 생성
    }
}
