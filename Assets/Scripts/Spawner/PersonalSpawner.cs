using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalSpawner : MonoBehaviour
{
    [Header("꽃풍선")]
    [SerializeField] GameObject balloonFlowerA;
    [SerializeField] GameObject balloonFlowerB;
    [SerializeField] GameObject balloonFlowerC;
    [Header("2구간 생성되는 풍선배열")]
    [SerializeField] GameObject [] period2BalloonLayer1; // 2구간 생성되는 레이어 1 풍선들(꽃, 물)
    [SerializeField] GameObject [] period2BalloonLayer2; // 2구간 생성되는 레이어 2 풍선들(꽃, 물)
    [SerializeField] GameObject [] period2BalloonLayer3; // 2구간 생성되는 레이어 3 풍선들(꽃, 물)
    [Header("3구간 생성되는 풍선배열")]
    [SerializeField] GameObject[] period3BalloonLayer1; // 3구간 생성되는 레이어 1 풍선들(꽃, 물, 해)
    [SerializeField] GameObject[] period3BalloonLayer2; // 3구간 생성되는 레이어 2 풍선들(꽃, 물, 해)
    [SerializeField] GameObject[] period3BalloonLayer3; // 3구간 생성되는 레이어 3 풍선들(꽃, 물, 해)
    [Header("레이어 별 생성 주기")]
    [SerializeField] float spawnCycle1 = 1.5f;                      // 레이어 1 풍선들의 생성 주기
    [SerializeField] float spawnCycle2 = 2.5f;                      // 레이어 2 풍선들의 생성 주기
    [SerializeField] float spawnCycle3 = 3.5f;                      // 레이어 3 풍선들의 생성 주기
    [Header("폭탄 오브젝트")]
    [SerializeField] GameObject balloonBombA;                       // 레이어 1 폭탄
    [SerializeField] GameObject balloonBombB;                       // 레이어 2 폭탄
    [SerializeField] GameObject balloonBombC;                       // 레이어 3 폭탄
    [Header("레이어 별 폭탄 주기")]
    [SerializeField] float bombCycle1 = 5f;                         // 레이어 1 폭탄들의 생성 주기
    [SerializeField] float bombCycle2 = 6f;                         // 레이어 2 폭탄들의 생성 주기
    [SerializeField] float bombCycle3 = 7f;                         // 레이어 3 폭탄들의 생성 주기
    float time1;                                   // 지나가는 시간을 나타내는 변수1
    float time2;                                   // 지나가는 시간을 나타내는 변수2
    float time3;                                   // 지나가는 시간을 나타내는 변수3
    float timeBomb1;                               // 폭탄소환에서 지나가는 시간을 나타내는 변수1
    float timeBomb2;                               // 폭탄소환에서 지나가는 시간을 나타내는 변수2
    float timeBomb3;                               // 폭탄소환에서 지나가는 시간을 나타내는 변수3
    float ranX = 0;                                // 스폰할 랜덤한 위치
    float spawnPosY = -4;                          // 풍선의 생성되는 y좌표
    int balloonIdx = 0;                            // 스폰될 풍선의 인덱스
    int layerIdx = 0;


    private void Start()
    {
        // 1구간 스폰 코루틴
        StartCoroutine(CO_1TimePeriod(balloonFlowerA, time1, spawnCycle1)); // 1레이어 풍선 생성코루틴
        StartCoroutine(CO_1TimePeriod(balloonFlowerB, time2, spawnCycle2)); // 2레이어 풍선 생성코루틴
        StartCoroutine(CO_1TimePeriod(balloonFlowerC, time3, spawnCycle3)); // 3레이어 풍선 생성코루틴

        // 2구간 스폰 코루틴
        StartCoroutine(CO_2TimePeriod(period2BalloonLayer1, time1, spawnCycle1)); // 1레이어 풍선 생성코루틴
        StartCoroutine(CO_2TimePeriod(period2BalloonLayer2, time2, spawnCycle2)); // 2레이어 풍선 생성코루틴
        StartCoroutine(CO_2TimePeriod(period2BalloonLayer3, time3, spawnCycle3)); // 3레이어 풍선 생성코루틴

        // 3구간 스폰 코루틴
        StartCoroutine(CO_3TimePeriod(period3BalloonLayer1, time1, spawnCycle1)); // 1레이어 풍선 생성코루틴
        StartCoroutine(CO_3TimePeriod(period3BalloonLayer2, time2, spawnCycle2)); // 2레이어 풍선 생성코루틴
        StartCoroutine(CO_3TimePeriod(period3BalloonLayer3, time3, spawnCycle3)); // 3레이어 풍선 생성코루틴

        // 폭탄 스폰 코루틴
        StartCoroutine(CO_BombSpawn(balloonBombA, timeBomb1, bombCycle1)); // 1레이어 폭탄 생성코루틴
        StartCoroutine(CO_BombSpawn(balloonBombB, timeBomb2, bombCycle2)); // 2레이어 폭탄 생성코루틴
        StartCoroutine(CO_BombSpawn(balloonBombC, timeBomb3, bombCycle3)); // 3레이어 폭탄 생성코루틴
    }


    /// <summary>
    /// 1구간 풍선 스폰 코루틴
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="passingTime"></param>
    /// <param name="spawnTime"></param>
    /// <returns></returns>
    IEnumerator CO_1TimePeriod(GameObject obj, float passingTime, float spawnTime)
    {
        while (passingTime <= 20)
        {
            passingTime += spawnTime;
            ranX = Random.Range(-8.0f, 8.0f);
            DictionaryPool.Inst.Instantiate(obj, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    /// <summary>
    /// 2구간 풍선 스폰 코루틴
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="passingTime"></param>
    /// <param name="spawnTime"></param>
    /// <returns></returns>
    IEnumerator CO_2TimePeriod(GameObject[] obj, float passingTime, float spawnTime)
    {
        yield return new WaitForSeconds(20f);
        while (passingTime <= 40)
        {
            passingTime += spawnTime;
            ranX = Random.Range(-8.0f, 8.0f);
            balloonIdx = Random.Range(1, 11);
            
            if (balloonIdx <= 7) DictionaryPool.Inst.Instantiate(obj[0], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(obj[1], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            yield return new WaitForSeconds(spawnTime);
        }
    }
    /// <summary>
    /// 3구간 풍선 스폰 코루틴
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="passingTime"></param>
    /// <param name="spawnTime"></param>
    /// <returns></returns>
    IEnumerator CO_3TimePeriod(GameObject[] obj, float passingTime, float spawnTime)
    {
        yield return new WaitForSeconds(40f);
        while (passingTime <= 60)
        {
            passingTime += spawnTime;
            ranX = Random.Range(-8.0f, 8.0f);
            balloonIdx = Random.Range(1, 11);
            if (balloonIdx <= 2) DictionaryPool.Inst.Instantiate(obj[0], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else if (balloonIdx <= 6) DictionaryPool.Inst.Instantiate(obj[1], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(obj[2], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator CO_BombSpawn(GameObject obj, float passingTime, float spawnTime)
    {
        yield return new WaitForSeconds(10f);
        while (passingTime <= 60)
        {
            passingTime += spawnTime;
            ranX = Random.Range(-8.0f, 8.0f);
            DictionaryPool.Inst.Instantiate(obj, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
