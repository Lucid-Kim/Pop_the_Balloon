using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalSpawner : MonoBehaviour
{
    [Header("��ǳ��")]
    [SerializeField] GameObject balloonFlowerA;
    [SerializeField] GameObject balloonFlowerB;
    [SerializeField] GameObject balloonFlowerC;
    [Header("2���� �����Ǵ� ǳ���迭")]
    [SerializeField] GameObject [] period2BalloonLayer1; // 2���� �����Ǵ� ���̾� 1 ǳ����(��, ��)
    [SerializeField] GameObject [] period2BalloonLayer2; // 2���� �����Ǵ� ���̾� 2 ǳ����(��, ��)
    [SerializeField] GameObject [] period2BalloonLayer3; // 2���� �����Ǵ� ���̾� 3 ǳ����(��, ��)
    [Header("3���� �����Ǵ� ǳ���迭")]
    [SerializeField] GameObject[] period3BalloonLayer1; // 3���� �����Ǵ� ���̾� 1 ǳ����(��, ��, ��)
    [SerializeField] GameObject[] period3BalloonLayer2; // 3���� �����Ǵ� ���̾� 2 ǳ����(��, ��, ��)
    [SerializeField] GameObject[] period3BalloonLayer3; // 3���� �����Ǵ� ���̾� 3 ǳ����(��, ��, ��)
    [Header("���̾� �� ���� �ֱ�")]
    [SerializeField] float spawnCycle1 = 1.5f;                      // ���̾� 1 ǳ������ ���� �ֱ�
    [SerializeField] float spawnCycle2 = 2.5f;                      // ���̾� 2 ǳ������ ���� �ֱ�
    [SerializeField] float spawnCycle3 = 3.5f;                      // ���̾� 3 ǳ������ ���� �ֱ�
    [Header("��ź ������Ʈ")]
    [SerializeField] GameObject balloonBombA;                       // ���̾� 1 ��ź
    [SerializeField] GameObject balloonBombB;                       // ���̾� 2 ��ź
    [SerializeField] GameObject balloonBombC;                       // ���̾� 3 ��ź
    [Header("���̾� �� ��ź �ֱ�")]
    [SerializeField] float bombCycle1 = 5f;                         // ���̾� 1 ��ź���� ���� �ֱ�
    [SerializeField] float bombCycle2 = 6f;                         // ���̾� 2 ��ź���� ���� �ֱ�
    [SerializeField] float bombCycle3 = 7f;                         // ���̾� 3 ��ź���� ���� �ֱ�
    float time1;                                   // �������� �ð��� ��Ÿ���� ����1
    float time2;                                   // �������� �ð��� ��Ÿ���� ����2
    float time3;                                   // �������� �ð��� ��Ÿ���� ����3
    float timeBomb1;                               // ��ź��ȯ���� �������� �ð��� ��Ÿ���� ����1
    float timeBomb2;                               // ��ź��ȯ���� �������� �ð��� ��Ÿ���� ����2
    float timeBomb3;                               // ��ź��ȯ���� �������� �ð��� ��Ÿ���� ����3
    float ranX = 0;                                // ������ ������ ��ġ
    float spawnPosY = -4;                          // ǳ���� �����Ǵ� y��ǥ
    int balloonIdx = 0;                            // ������ ǳ���� �ε���
    int layerIdx = 0;


    private void Start()
    {
        switch(GameDatas.Inst.difficulty)
        {
            case DIFFICULTY.NORMAL:
                Spawn3LayerBalloon();

                StartCoroutine(CO_BombSpawn(balloonBombC, timeBomb3, bombCycle3)); // 3���̾� ��ź �����ڷ�ƾ
                break;
            case DIFFICULTY.HARD:
                Spawn3LayerBalloon();

                StartCoroutine(CO_BombSpawn(balloonBombB, timeBomb2, bombCycle2)); // 2���̾� ��ź �����ڷ�ƾ
                StartCoroutine(CO_BombSpawn(balloonBombC, timeBomb3, bombCycle3)); // 3���̾� ��ź �����ڷ�ƾ
                break;
            case DIFFICULTY.MASTER:
                Spawn3LayerBalloon();

                StartCoroutine(CO_BombSpawn(balloonBombA, timeBomb1, bombCycle1)); // 1���̾� ��ź �����ڷ�ƾ
                StartCoroutine(CO_BombSpawn(balloonBombB, timeBomb2, bombCycle2)); // 2���̾� ��ź �����ڷ�ƾ
                StartCoroutine(CO_BombSpawn(balloonBombC, timeBomb3, bombCycle3)); // 3���̾� ��ź �����ڷ�ƾ
                break;
        }
        // 1���� ���� �ڷ�ƾ
        StartCoroutine(CO_1TimePeriod(balloonFlowerA, time1, spawnCycle1)); // 1���̾� ǳ�� �����ڷ�ƾ
        StartCoroutine(CO_1TimePeriod(balloonFlowerB, time2, spawnCycle2)); // 2���̾� ǳ�� �����ڷ�ƾ
        

        // 2���� ���� �ڷ�ƾ
        StartCoroutine(CO_2TimePeriod(period2BalloonLayer1, time1, spawnCycle1)); // 1���̾� ǳ�� �����ڷ�ƾ
        StartCoroutine(CO_2TimePeriod(period2BalloonLayer2, time2, spawnCycle2)); // 2���̾� ǳ�� �����ڷ�ƾ
        

        // 3���� ���� �ڷ�ƾ
        StartCoroutine(CO_3TimePeriod(period3BalloonLayer1, time1, spawnCycle1)); // 1���̾� ǳ�� �����ڷ�ƾ
        StartCoroutine(CO_3TimePeriod(period3BalloonLayer2, time2, spawnCycle2)); // 2���̾� ǳ�� �����ڷ�ƾ
        
    }

    void Spawn3LayerBalloon()
    {
        StartCoroutine(CO_1TimePeriod(balloonFlowerC, time3, spawnCycle3)); // 3���̾� ǳ�� �����ڷ�ƾ
        StartCoroutine(CO_2TimePeriod(period2BalloonLayer3, time3, spawnCycle3)); // 3���̾� ǳ�� �����ڷ�ƾ
        StartCoroutine(CO_3TimePeriod(period3BalloonLayer3, time3, spawnCycle3)); // 3���̾� ǳ�� �����ڷ�ƾ
    }

    /// <summary>
    /// 1���� ǳ�� ���� �ڷ�ƾ
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
    /// 2���� ǳ�� ���� �ڷ�ƾ
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
    /// 3���� ǳ�� ���� �ڷ�ƾ
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
