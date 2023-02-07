using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalSpawner : MonoBehaviour
{
    [Header("꽃풍선")]
    [SerializeField] GameObject balloonFlowerA;
    [SerializeField] GameObject balloonFlowerB;
    [SerializeField] GameObject balloonFlowerC;
    [Header("물풍선")]
    [SerializeField] GameObject balloonWaterA;
    [SerializeField] GameObject balloonWaterB;
    [SerializeField] GameObject balloonWaterC;
    [Header("해풍선")]
    [SerializeField] GameObject balloonSunA;
    [SerializeField] GameObject balloonSunB;
    [SerializeField] GameObject balloonSunC;

    float time;                                    // 지나가는 시간을 나타내는 변수
    float spawnCycle1 = 1.5f;                      // 레이어 1풍선들의 생성 주기
    float spawnCycle2 = 2.5f;                      // 레이어 2풍선들의 생성 주기
    float spawnCycle3 = 3.5f;                      // 레이어 3풍선들의 생성 주기
    float ranX = 0;                                // 스폰할 랜덤한 위치
    float spawnPosY = -4;                          // 풍선의 생성되는 y좌표
    int balloonIdx = 0;                            // 스폰될 풍선의 인덱스
    int layerIdx = 0;

    bool isSpawned1;
    bool isSpawned2;
    bool isSpawned3;
    
    Coroutine layer1SpawnCo;
    Coroutine layer2SpawnCo;
    Coroutine layer3SpawnCo;

    private void Start()
    {
        layer1SpawnCo = StartCoroutine(nameof(CO_1TimePeriod));
        layer2SpawnCo = StartCoroutine(nameof(CO_2TimePeriod));
        layer3SpawnCo = StartCoroutine(nameof(CO_3TimePeriod));
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time <= 20 && isSpawned1 == true)
        {
            layer1SpawnCo = StartCoroutine(nameof(CO_1TimePeriod));
            isSpawned1 = false;
        }
        else if (time <= 40 && isSpawned2 == true)
        {
            StopCoroutine(layer1SpawnCo);
            layer2SpawnCo = StartCoroutine(nameof(CO_2TimePeriod));
            isSpawned2 = false;
        } 
        else if (time <= 60 && isSpawned3 == true)
        {
            StopCoroutine(layer2SpawnCo);
            layer3SpawnCo = StartCoroutine(nameof(CO_3TimePeriod));
            isSpawned3 = false;
        }
    }
    /// <summary>
    /// 1구간 풍선 스폰(개인모드)
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_1TimePeriod()
    {
        while (time <= 20)
        {
            time += Time.deltaTime;
            StartCoroutine(CO_Layer1Spawn(100,0));
            StartCoroutine(CO_Layer2Spawn(100,0));
            StartCoroutine(CO_Layer3Spawn(100,0));

            yield return null;
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
            time += Time.deltaTime;
            StartCoroutine(CO_Layer1Spawn(70, 30));
            StartCoroutine(CO_Layer2Spawn(70, 30));
            StartCoroutine(CO_Layer3Spawn(70, 30));
            yield return null;
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
            time += Time.deltaTime;
            StartCoroutine(CO_Layer1Spawn(20, 40));
            StartCoroutine(CO_Layer2Spawn(20, 40));
            StartCoroutine(CO_Layer3Spawn(20, 40));
            yield return null;
        }
    }


    /// <summary>
    /// 레이어 1번 각 확률에 따른 스포너
    /// </summary>
    /// <param name="case1"></param> 꽃 풍선 확률
    /// <param name="case2"></param> 물 풍선 확률
    /// <returns></returns>
    IEnumerator CO_Layer1Spawn(int case1,int case2)
    {
        while (true)
        {
            ranX = Random.Range(-8.0f, 8.0f);
            balloonIdx = Random.Range(1, 101);
            Debug.Log("레이어1 소환");
            if (balloonIdx <= case1) DictionaryPool.Inst.Instantiate(balloonFlowerA, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else if (balloonIdx <= case2) DictionaryPool.Inst.Instantiate(balloonWaterA, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonSunA, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            isSpawned1 = false;
            isSpawned2 = false;
            isSpawned3 = false;
            yield return new WaitForSeconds(spawnCycle1);
            isSpawned1 = true;
            isSpawned2 = true;
            isSpawned3 = true;
        }
    }

    IEnumerator CO_Layer2Spawn(int case1, int case2)
    {
        while (true)
        {
            ranX = Random.Range(-8.0f, 8.0f);
            balloonIdx = Random.Range(1, 101);
            Debug.Log("레이어2 소환");
            if (balloonIdx <= case1) DictionaryPool.Inst.Instantiate(balloonFlowerB, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else if (balloonIdx <= case2) DictionaryPool.Inst.Instantiate(balloonWaterB, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonSunB, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            isSpawned1 = false;
            isSpawned2 = false;
            isSpawned3 = false;
            yield return new WaitForSeconds(spawnCycle2);
            isSpawned1 = true;
            isSpawned2 = true;
            isSpawned3 = true;
        }
    }
    IEnumerator CO_Layer3Spawn(int case1, int case2)
    {
        while (true)
        {
            ranX = Random.Range(-8.0f, 8.0f);
            balloonIdx = Random.Range(1, 101);
            Debug.Log("레이어3 소환");
            if (balloonIdx <= case1) DictionaryPool.Inst.Instantiate(balloonFlowerC, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else if (balloonIdx <= case2) DictionaryPool.Inst.Instantiate(balloonWaterC, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonSunC, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            isSpawned1 = false;
            isSpawned2 = false;
            isSpawned3 = false;
            yield return new WaitForSeconds(spawnCycle3);
            isSpawned1 = true;
            isSpawned2 = true;
            isSpawned3 = true;
        }
    }
}
