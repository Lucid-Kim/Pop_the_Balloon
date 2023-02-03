using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonWater1;     // 1���� �� ǳ��
    [SerializeField] GameObject balloonSun1;       // 1���� �� ǳ��
    [SerializeField] GameObject balloonFlower1;    // 1���� �� ǳ��

    float time;                                    // �������� �ð��� ��Ÿ���� ����
    float spawnCycle = 2f;                               // �����ֱ�
    float ranX = 0;                                // 1����(����) ���� x��ǥ
    float ranX2 = 0;                               // 2����(������) ���� x��ǥ
    float ranX3 = 0;                               // �̺�Ʈ ǳ�� 1����(����) ���� x��ǥ
    float ranX4 = 0;                               // �̺�Ʈ ǳ�� 2����(������) ���� x��ǥ
    float centerX = 1f;                            // �߾Ӽ��� ���� �ʰ� ������ x��ǥ
    float spawnPosY = -4;                          // ǳ���� �����Ǵ� y��ǥ
    int idx = 0;                                   // 1������ �����Ǵ� ǳ������ ���� �ε���
    int idx2 = 0;                                  // 2������ �����Ǵ� ǳ������ ���� �ε���
    int idx3 = 0;                                  // 1,2������ �����Ǵ� �̺�Ʈ ǳ������ ���� �ε���

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
    /// 1���� ǳ�� ����(�������)
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
    /// 2���� ǳ�� ����
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
    /// �̺�Ʈ ǳ�� ���� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    //IEnumerator CO_Spawn15Sec()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(15f); // �̺�Ʈ ǳ�� ������ �ֱ�(15��)
    //        ranX3 = Random.Range(-8.0f, -centerX); // 1���� ���� ��ǥ
    //        ranX4 = Random.Range(centerX, 8.0f); // 2���� ���� ��ǥ
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
