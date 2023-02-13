using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonWater1;     // 1구역 물 풍선
    [SerializeField] GameObject balloonSun1;       // 1구역 해 풍선
    [SerializeField] GameObject[] balloonFlower1;  // 1구역 꽃 풍선
    [SerializeField] GameObject butterfly;         // 나비 오브젝트
    [Header("생성 주기(초)")]
    [SerializeField] float spawnCycle = 2f;        // 생성주기
    float time;                                    // 지나가는 시간을 나타내는 변수
    float ranX = 0;                                // 1구역(왼쪽) 랜덤 x좌표
    float centerX = 1f;                            // 중앙선을 닿지 않게 선정한 x좌표
    float spawnPosY = -4;                          // 풍선의 생성되는 y좌표
    int balloonIdx = 0;                            // 풍선 종류를 선정해주는 인덱스
    int flowerIdx = 0;                             // 1구역에 생성되는 꽃풍선들의 종류 인덱스

    Coroutine startCor_SpawnTime1;
    Coroutine startCor_SpawnTime2;
    Coroutine startCor_SpawnTime3;
    Coroutine startCor_Spawnbutterfly;
    WaitForSeconds spawnCycleSeconds;
    private void OnEnable()
    {
        spawnCycleSeconds = new WaitForSeconds(spawnCycle);
        startCor_SpawnTime1 = StartCoroutine(nameof(CO_1TimePeriod));
        //startCor_SpawnTime2 = StartCoroutine(nameof(CO_2TimePeriod));
        //startCor_SpawnTime3 = StartCoroutine(nameof(CO_3TimePeriod));
        startCor_Spawnbutterfly = StartCoroutine(nameof(CO_SpawnButterfly));
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
            if (GameManager.Inst.isFeverTime == true)
            {
                yield return spawnCycleSeconds;
                continue;
            }
            Debug.Log("피버 끝났다");
            ranX = Random.Range(-8.0f, -centerX);
            flowerIdx = Random.Range(0, 5);
            DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            yield return spawnCycleSeconds;
        }
        // 2구간 풍선 스폰(협동 모드)
        while (time <= 40)
        {
            time += spawnCycle;
            if (GameManager.Inst.isFeverTime == true)
            {
                yield return spawnCycleSeconds;
                continue;
            }
            Debug.Log("피버 끝났다");
            ranX = Random.Range(-8.0f, -centerX);
            balloonIdx = Random.Range(1, 11);
            flowerIdx = Random.Range(0, 5);

            if (balloonIdx <= 7) DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            yield return spawnCycleSeconds;
        }
        // 3구간 풍선 스폰(협동 모드)
        while (time <= 60)
        {
            time += spawnCycle;
            if (GameManager.Inst.isFeverTime == true)
            {
                yield return spawnCycleSeconds;
                continue;
            }
            ranX = Random.Range(-8.0f, -centerX);
            balloonIdx = Random.Range(1, 11);
            flowerIdx = Random.Range(0, 5);
            if (balloonIdx <= 2) DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else if (balloonIdx <= 6) DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonSun1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            yield return spawnCycleSeconds;
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
            balloonIdx = Random.Range(1, 11);
            flowerIdx = Random.Range(0, 5);

            if (balloonIdx <= 7) DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

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
            balloonIdx = Random.Range(1, 11);
            if (balloonIdx <= 2) DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else if (balloonIdx <= 6) DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonSun1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            yield return new WaitForSeconds(spawnCycle);
        }
    }
    /// <summary>
    /// 나비 생성(협동모드)
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_SpawnButterfly()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(butterfly, new Vector3(-8, -2, 0), Quaternion.identity);
    }
}
