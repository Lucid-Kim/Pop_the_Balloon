using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalSpawner : MonoBehaviour
{
    [Header("��ǳ��")]
    [SerializeField] GameObject balloonFlowerA;
    [SerializeField] GameObject balloonFlowerB;
    [SerializeField] GameObject balloonFlowerC;
    [Header("��ǳ��")]
    [SerializeField] GameObject balloonWaterA;
    [SerializeField] GameObject balloonWaterB;
    [SerializeField] GameObject balloonWaterC;
    [Header("��ǳ��")]
    [SerializeField] GameObject balloonSunA;
    [SerializeField] GameObject balloonSunB;
    [SerializeField] GameObject balloonSunC;

    float time1;                                   // �������� �ð��� ��Ÿ���� ����1
    float time2;                                   // �������� �ð��� ��Ÿ���� ����2
    float time3;                                   // �������� �ð��� ��Ÿ���� ����3
    float spawnCycle1 = 1.5f;                      // ���̾� 1ǳ������ ���� �ֱ�
    float spawnCycle2 = 2.5f;                      // ���̾� 2ǳ������ ���� �ֱ�
    float spawnCycle3 = 3.5f;                      // ���̾� 3ǳ������ ���� �ֱ�
    float ranX = 0;                                // ������ ������ ��ġ
    float spawnPosY = -4;                          // ǳ���� �����Ǵ� y��ǥ
    int balloonIdx = 0;                            // ������ ǳ���� �ε���
    int layerIdx = 0;

    bool isSpawned1;
    bool isSpawned2;
    bool isSpawned3;

    Coroutine layer1SpawnCo;
    Coroutine layer2SpawnCo;
    Coroutine layer3SpawnCo;

    private void Start()
    {
        StartCoroutine(CO_1TimePeriod(balloonFlowerA, time1, spawnCycle1));
        StartCoroutine(CO_1TimePeriod(balloonFlowerB, time2, spawnCycle2));
        StartCoroutine(CO_1TimePeriod(balloonFlowerC, time3, spawnCycle3));

    }


    /// <summary>
    /// 1���� ǳ�� ���� �ڷ�ƾ
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="spawnTime"></param>
    /// <returns></returns>
    IEnumerator CO_1TimePeriod(GameObject obj, float passingTime, float spawnTime)
    {
        while (passingTime <= 20)
        {
            passingTime += spawnTime;
            ranX = Random.Range(-8.0f, 8.0f);
            DictionaryPool.Inst.Instantiate(obj, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            Debug.Log(passingTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    /// <summary>
    /// 2���� ǳ�� ����(�������)
    /// </summary>
    /// <returns></returns>
    //IEnumerator CO_2TimePeriod()
    //{
    //    yield return new WaitForSeconds(20f);
    //    while (time <= 40)
    //    {
    //        time += Time.deltaTime;
    //        StartCoroutine(CO_Layer1Spawn(70, 30));
    //        StartCoroutine(CO_Layer2Spawn(70, 30));
    //        StartCoroutine(CO_Layer3Spawn(70, 30));
    //        yield return null;
    //    }
    //}
    ///// <summary>
    ///// 3���� ǳ�� ����(�������)
    ///// </summary>
    ///// <returns></returns>
    //IEnumerator CO_3TimePeriod()
    //{
    //    yield return new WaitForSeconds(40f);
    //    while (time <= 60)
    //    {
    //        time += Time.deltaTime;
    //        StartCoroutine(CO_Layer1Spawn(20, 40));
    //        StartCoroutine(CO_Layer2Spawn(20, 40));
    //        StartCoroutine(CO_Layer3Spawn(20, 40));
    //        yield return null;
    //    }
    //}


    /// <summary>
    /// ���̾� 1�� �� Ȯ���� ���� ������
    /// </summary>
    /// <param name="case1"></param> �� ǳ�� Ȯ��
    /// <param name="case2"></param> �� ǳ�� Ȯ��
    /// <returns></returns>
    IEnumerator CO_Layer1Spawn(int case1, int case2)
    {
        while (true)
        {
            ranX = Random.Range(-8.0f, 8.0f);
            balloonIdx = Random.Range(1, 101);
            Debug.Log("���̾�1 ��ȯ");
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
            Debug.Log("���̾�2 ��ȯ");
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
            Debug.Log("���̾�3 ��ȯ");
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
