using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonWater;     // ¹° Ç³¼±
    [SerializeField] GameObject balloonSun;       // ÇØ Ç³¼±
    [SerializeField] GameObject balloonButterfly; // ³ªºñ Ç³¼±
    [SerializeField] GameObject balloonBee;       // ¹ú Ç³¼±
    [SerializeField] GameObject balloonSeed;      // ¾¾ Ç³¼±
    [SerializeField] GameObject balloonShit;      // ¶Ë Ç³¼±
    float ranX1 = 0;                              // 1±¸¿ª(¿ÞÂÊ) ·£´ý xÁÂÇ¥
    float ranX2 = 0;                              // 2±¸¿ª(¿À¸¥ÂÊ) ·£´ý xÁÂÇ¥
    float ranX3 = 0;                              // ÀÌº¥Æ® Ç³¼± 1±¸¿ª(¿ÞÂÊ) ·£´ý xÁÂÇ¥
    float ranX4 = 0;                              // ÀÌº¥Æ® Ç³¼± 2±¸¿ª(¿À¸¥ÂÊ) ·£´ý xÁÂÇ¥
    float centerX = 1f;                           // Áß¾Ó¼±À» ´êÁö ¾Ê°Ô ¼±Á¤ÇÑ xÁÂÇ¥
    float spawnPosY = -4;                         // Ç³¼±ÀÇ »ý¼ºµÇ´Â yÁÂÇ¥
    int idx1 = 0;                                 // 1±¸¿ª¿¡ »ý¼ºµÇ´Â Ç³¼±µéÀÇ Á¾·ù ÀÎµ¦½º
    int idx2 = 0;                                 // 2±¸¿ª¿¡ »ý¼ºµÇ´Â Ç³¼±µéÀÇ Á¾·ù ÀÎµ¦½º
    int idx3 = 0;                                 // 1,2±¸¿ª¿¡ »ý¼ºµÇ´Â ÀÌº¥Æ® Ç³¼±µéÀÇ Á¾·ù ÀÎµ¦½º

    Coroutine startCor_SpawnBall1;
    Coroutine startCor_SpawnBall2;
    Coroutine startCor_Spawn15Sec;
    private void OnEnable()
    {
        startCor_SpawnBall1 = StartCoroutine(nameof(CO_SpawnBalloon1));
        startCor_SpawnBall2 = StartCoroutine(nameof(CO_SpawnBalloon2));
        startCor_Spawn15Sec = StartCoroutine(nameof(CO_Spawn15Sec));
    }

    /// <summary>
    /// 1±¸¿ª Ç³¼± ½ºÆù
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 2±¸¿ª Ç³¼± ½ºÆ÷
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// ÀÌº¥Æ® Ç³¼± ½ºÆù ÄÚ·çÆ¾
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_Spawn15Sec()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f); // ÀÌº¥Æ® Ç³¼± ³ª¿À´Â ÁÖ±â(15ÃÊ)
            ranX3 = Random.Range(-8.0f, -centerX); // 1±¸¿ª ·£´ý ÁÂÇ¥
            ranX4 = Random.Range(centerX, 8.0f); // 2±¸¿ª ·£´ý ÁÂÇ¥
            idx3 = Random.Range(0, 4); 
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
