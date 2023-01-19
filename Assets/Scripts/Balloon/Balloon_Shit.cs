using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Shit : Balloon
{
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }
    // 똥 풍선 클릭했을 때
    public override void Interact()
    {
        base.Interact();
        float ranX = Random.Range(-8.0f, -1f); // 왼쪽을 나타내는 x좌표

        // 똥 풍선 터치시 비료 풍선 생성
        DictionaryPool.Inst.Instantiate(obj[0], new Vector2(ranX, -4), Quaternion.identity, DictionaryPool.Inst.transform);

        // 풍선 위치에 효과 출력
        DictionaryPool.Inst.Instantiate(obj[1], this.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
        DictionaryPool.Inst.Release(this.gameObject);
    }
}
