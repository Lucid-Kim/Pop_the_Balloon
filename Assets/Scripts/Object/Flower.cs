using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] GameObject [] blooming;

    /// <summary>
    /// 바닥과 충돌했을 때 피어나는 꽃 생성 함수
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            float ranX = Random.Range(-8.0f, 8.0f);
            int idx = Random.Range(0, 3); // 꽃 종류 랜덤 설정
            DictionaryPool.Inst.Destroy(this.gameObject);

            // 랜덤으로 설정된 꽃 생성
            GameObject thisBlooming = DictionaryPool.Inst.Instantiate(blooming[idx], new Vector2(ranX, collision.transform.position.y + 1), Quaternion.identity, DictionaryPool.Inst.transform); 
            GameManager.Inst.ListEnqueue(thisBlooming); // 피어난 꽃 리스트 추가
        }
    }

    
}
