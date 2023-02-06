using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] balloonFlower; // 꽃 풍선들 오브젝트
    
    float ranX1;        // 2구역(오른쪽) 랜덤 x좌표
    float ranY;         // 2구역(오른쪽) 랜덤 y좌표
    float centerX = 1f; // 중앙선을 닿지 않게 선정한 x좌표
    int ranNum1;        // 1구역(왼쪽) 생성될 꽃 풍선 인덱스
    int ranNum2;        // 2구역(오른쪽) 생성될 꽃 풍선 인덱스

    Coroutine feverTime;
    private void OnEnable()
    {
        feverTime = StartCoroutine(nameof(CO_FeverTime));
    }
    
    
    /// <summary>
    /// 꽃 풍선이 지속적으로 생성
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_FeverTime()
    {
        while(true)
        {
            ranX1 = Random.Range(centerX, 8);
            ranY = Random.Range(-1f, 3f);
            ranNum1 = Random.Range(0, 5); // 오른쪽에 생성될 꽃의 종류
            
            DictionaryPool.Inst.Instantiate(balloonFlower[ranNum1], new Vector2(ranX1, ranY), Quaternion.identity, DictionaryPool.Inst.transform); // 오른쪽 구역 꽃풍선 생성
            
            yield return new WaitForSeconds(0.25f);
        }


    }


}
