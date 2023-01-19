using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonWater;
    [SerializeField] GameObject balloonSun;
    [SerializeField] GameObject balloonButterfly;
    [SerializeField] GameObject balloonBee;
    [SerializeField] GameObject balloonSeed;
    [SerializeField] GameObject balloonShit;
    float ranX1 = 0;
    float ranX2 = 0;
    float ranX3 = 0;
    float ranX4 = 0;
    float centerX = 1f;
    float spawnPosY = -4;
    int idx1 = 0;
    int idx2 = 0;
    int idx3 = 0;
    
    Coroutine startCor_SpawnBall1;
    Coroutine startCor_SpawnBall2;
    Coroutine startCor_Spawn15Sec;
    private void OnEnable()
    {
        startCor_SpawnBall1 = StartCoroutine(nameof(CO_SpawnBalloon1));
        startCor_SpawnBall2 = StartCoroutine(nameof(CO_SpawnBalloon2));
        startCor_Spawn15Sec = StartCoroutine(nameof(CO_Spawn15Sec));
    }

    // 1±¸¿ª Ç³¼± ½ºÆù
    IEnumerator CO_SpawnBalloon1()
    {
        while (true)
        {
            ranX1 = Random.Range(-8.0f, -centerX);
            idx1 = Random.Range(0, 3);
            switch (idx1)
            {
                case 0:
                    DictionaryPool.Inst.Instantiate(balloonSun, new Vector2(ranX1, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 1:
                    DictionaryPool.Inst.Instantiate(balloonSeed, new Vector2(ranX1, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 2:
                    DictionaryPool.Inst.Instantiate(balloonSeed, new Vector2(ranX1, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;

            }
            yield return new WaitForSeconds(1.05f);
        }
    }

    // 2±¸¿ª Ç³¼± ½ºÆ÷
    IEnumerator CO_SpawnBalloon2()
    {
        while (true)
        {
            ranX2 = Random.Range(centerX, 8.0f);
            idx2 = Random.Range(0, 2);
            switch (idx2)
            {
                case 0:
                    DictionaryPool.Inst.Instantiate(balloonWater, new Vector2(ranX2, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 1:
                    DictionaryPool.Inst.Instantiate(balloonShit, new Vector2(ranX2, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
            }
            yield return new WaitForSeconds(1.05f);
        }
    }


    IEnumerator CO_Spawn15Sec()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f); // ÀÌº¥Æ® Ç³¼± ³ª¿À´Â ÁÖ±â(15ÃÊ)
            ranX3 = Random.Range(-8.0f, -centerX); // 1±¸¿ª ·£´ý ÁÂÇ¥
            ranX4 = Random.Range(centerX, 8.0f); // 2±¸¿ª ·£´ý ÁÂÇ¥
            idx3 = Random.Range(0, 4); // ·£´ýÀ¸·Î ¹Ù²ã¾ßÇÔ
            switch (idx3)
            {
                case 0:
                    DictionaryPool.Inst.Instantiate(balloonBee, new Vector2(ranX3, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 1:
                    DictionaryPool.Inst.Instantiate(balloonBee, new Vector2(ranX4, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 2:
                    DictionaryPool.Inst.Instantiate(balloonButterfly, new Vector2(ranX3, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
                case 3:
                    DictionaryPool.Inst.Instantiate(balloonButterfly, new Vector2(ranX4, spawnPosY), Quaternion.identity, DictionaryPool.Inst.transform);
                    break;
            }
        }
    }

}
