using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonWater1;     // 1구역 물 풍선
    [SerializeField] GameObject balloonSun1;       // 1구역 해 풍선
    [SerializeField] GameObject balloonFlower1;    // 1구역 꽃 풍선

    float time;                                    // 지나가는 시간을 나타내는 변수
    float spawnCycle = 2f;                               // 생성주기
    float ranX = 0;                                // 1구역(왼쪽) 랜덤 x좌표
    float ranX2 = 0;                               // 2구역(오른쪽) 랜덤 x좌표
    float ranX3 = 0;                               // 이벤트 풍선 1구역(왼쪽) 랜덤 x좌표
    float ranX4 = 0;                               // 이벤트 풍선 2구역(오른쪽) 랜덤 x좌표
    float centerX = 1f;                            // 중앙선을 닿지 않게 선정한 x좌표
    float spawnPosY = -4;                          // 풍선의 생성되는 y좌표
    int idx = 0;                                   // 1구역에 생성되는 풍선들의 종류 인덱스
    int idx2 = 0;                                  // 2구역에 생성되는 풍선들의 종류 인덱스
    int idx3 = 0;                                  // 1,2구역에 생성되는 이벤트 풍선들의 종류 인덱스

    Coroutine startCor_SpawnTime1;
    Coroutine startCor_SpawnTime2;
    Coroutine startCor_SpawnTime3;
    
    private void OnEnable()
    {
        startCor_SpawnTime1 = StartCoroutine(nameof(CO_1TimePeriod));
        startCor_SpawnTime2 = StartCoroutine(nameof(CO_2TimePeriod));
        startCor_SpawnTime3 = StartCoroutine(nameof(CO_3TimePeriod));
    }

    /// <summary>
    /// 1구간 풍선 스폰(협동모드)
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_1TimePeriod()
    {
        while (time <= 20)
        {
            time += spawnCycle;
            ranX = Random.Range(-8.0f, -centerX);
            
            DictionaryPool.Inst.Instantiate(balloonFlower1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);        
            yield return new WaitForSeconds(spawnCycle);
        }
    }
    /// <summary>
    /// 2구간 풍선 스폰(협동모드)
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_2TimePeriod()
    {
        yield return new WaitForSeconds(20f);
        while (time <= 40)
        {
            time += spawnCycle;
            ranX = Random.Range(-8.0f, -centerX);
            idx = Random.Range(0, 2);
            switch (idx)
            {
                case 0:
                    DictionaryPool.Inst.Instantiate(balloonFlower1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 1:
                    DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;

            }
            yield return new WaitForSeconds(spawnCycle);
        }
    }
    /// <summary>
    /// 3구간 풍선 스폰(협동모드)
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_3TimePeriod()
    {
        yield return new WaitForSeconds(40f);
        while (time <= 60)
        {
            time += spawnCycle;
            ranX = Random.Range(-8.0f, -centerX);
            idx = Random.Range(0, 2);
            switch (idx)
            {
                case 0:
                    DictionaryPool.Inst.Instantiate(balloonSun1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 1:
                    DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;

            }
            yield return new WaitForSeconds(spawnCycle);
        }
    }
    /// <summary>
    /// 2구역 풍선 스포
    /// </summary>
    /// <returns></returns>
    //IEnumerator CO_SpawnBalloon2()
    //{
    //    while (true)
    //    {
    //        ranX2 = Random.Range(centerX, 8.0f);
    //        idx2 = Random.Range(0, 2);
    //        switch (idx2)
    //        {
    //            case 0:
    //                DictionaryPool.Inst.Instantiate(balloonWater, new Vector2(ranX2, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
    //                break;
    //            case 1:
    //                DictionaryPool.Inst.Instantiate(balloonShit, new Vector2(ranX2, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
    //                break;
    //        }
    //        yield return new WaitForSeconds(1.05f);
    //    }
    //}

    /// <summary>
    /// 이벤트 풍선 스폰 코루틴
    /// </summary>
    /// <returns></returns>
    //IEnumerator CO_Spawn15Sec()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(15f); // 이벤트 풍선 나오는 주기(15초)
    //        ranX3 = Random.Range(-8.0f, -centerX); // 1구역 랜덤 좌표
    //        ranX4 = Random.Range(centerX, 8.0f); // 2구역 랜덤 좌표
    //        idx3 = Random.Range(0, 4); 
    //        switch (idx3)
    //        {
    //            case 0:
    //                DictionaryPool.Inst.Instantiate(balloonBee, new Vector2(ranX3, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
    //                break;
    //            case 1:
    //                DictionaryPool.Inst.Instantiate(balloonBee, new Vector2(ranX4, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
    //                break;
    //            case 2:
    //                DictionaryPool.Inst.Instantiate(balloonButterfly, new Vector2(ranX3, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
    //                break;
    //            case 3:
    //                DictionaryPool.Inst.Instantiate(balloonButterfly, new Vector2(ranX4, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
    //                break;
    //        }
    //    }
    //}

}
