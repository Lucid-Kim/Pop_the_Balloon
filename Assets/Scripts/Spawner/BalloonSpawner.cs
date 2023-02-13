using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonWater1;     // 1���� �� ǳ��
    [SerializeField] GameObject balloonSun1;       // 1���� �� ǳ��
    [SerializeField] GameObject[] balloonFlower1;  // 1���� �� ǳ��
    [SerializeField] GameObject butterfly;         // ���� ������Ʈ
    [Header("���� �ֱ�(��)")]
    [SerializeField] float spawnCycle = 2f;        // �����ֱ�
    float time;                                    // �������� �ð��� ��Ÿ���� ����
    float ranX = 0;                                // 1����(����) ���� x��ǥ
    float centerX = 1f;                            // �߾Ӽ��� ���� �ʰ� ������ x��ǥ
    float spawnPosY = -4;                          // ǳ���� �����Ǵ� y��ǥ
    int balloonIdx = 0;                            // ǳ�� ������ �������ִ� �ε���
    int flowerIdx = 0;                             // 1������ �����Ǵ� ��ǳ������ ���� �ε���

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
    /// 1���� ǳ�� ����(�������)
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
            Debug.Log("�ǹ� ������");
            ranX = Random.Range(-8.0f, -centerX);
            flowerIdx = Random.Range(0, 5);
            DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            yield return spawnCycleSeconds;
        }
        // 2���� ǳ�� ����(���� ���)
        while (time <= 40)
        {
            time += spawnCycle;
            if (GameManager.Inst.isFeverTime == true)
            {
                yield return spawnCycleSeconds;
                continue;
            }
            Debug.Log("�ǹ� ������");
            ranX = Random.Range(-8.0f, -centerX);
            balloonIdx = Random.Range(1, 11);
            flowerIdx = Random.Range(0, 5);

            if (balloonIdx <= 7) DictionaryPool.Inst.Instantiate(balloonFlower1[flowerIdx], new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            else DictionaryPool.Inst.Instantiate(balloonWater1, new Vector2(ranX, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);

            yield return spawnCycleSeconds;
        }
        // 3���� ǳ�� ����(���� ���)
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
    /// 2���� ǳ�� ����(�������)
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
    /// 3���� ǳ�� ����(�������)
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
    /// ���� ����(�������)
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_SpawnButterfly()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(butterfly, new Vector3(-8, -2, 0), Quaternion.identity);
    }
}
