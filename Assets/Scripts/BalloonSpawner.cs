using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    float ranX1 = 0;
    float ranX2 = 0;
    float ranX3 = 0;
    float ranX4 = 0;
    float centerX = 1f;
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
    
    // 1구역 풍선 스폰
    IEnumerator CO_SpawnBalloon1()
    {
        while (true)
        {
            ranX1 = Random.Range(-8.0f, -centerX);
            idx1 = Random.Range(0, 3);
            switch (idx1)
            {
                case 0:
                    BalloonSunPool.Inst.Get(new Vector2(ranX1, -4));
                    break;
                case 1:
                    BalloonSeedPool.Inst.Get(new Vector2(ranX1, -4));
                    break;
                case 2:
                    BalloonSeedPool.Inst.Get(new Vector2(ranX1, -4));
                    break;

            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // 2구역 풍선 스포
    IEnumerator CO_SpawnBalloon2()
    {
        while (true)
        {
            ranX2 = Random.Range(centerX, 8.0f);
            idx2 = Random.Range(0, 2);
            switch (idx2)
            {
                case 0:
                    BalloonWaterPool.Inst.Get(new Vector2(ranX2, -4));
                    break;
                case 1:
                    BalloonShitPool.Inst.Get(new Vector2(ranX2, -4));
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    IEnumerator CO_Spawn15Sec()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            ranX3 = Random.Range(-8.0f, -centerX);
            ranX4 = Random.Range(centerX, 8.0f);
            idx3 = 3;// Random.Range(0, 4);
            switch (idx3)
            {
                case 0:
                    BalloonBeePool.Inst.Get(new Vector2(ranX3, -4));
                    break;
                case 1:
                    BalloonBeePool.Inst.Get(new Vector2(ranX4, -4));
                    break;
                case 2:
                    BalloonButterflyPool.Inst.Get(new Vector2(ranX3, -4));
                    break;
                case 3:
                    BalloonButterflyPool.Inst.Get(new Vector2(ranX4, -4));
                    break;
            }
        }
    }
}
