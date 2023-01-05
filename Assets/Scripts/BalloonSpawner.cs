using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    float ranX1 = 0;
    float ranX2 = 0;
    float ranX3 = 0;
    float ranX4 = 0;

    int idx1 = 0;
    int idx2 = 0;
    
    
    Coroutine startCor_SpawnBall;
    Coroutine startCor_Spawn15Sec;
    void Start()
    {    
        startCor_SpawnBall = StartCoroutine("CO_SpawnBalloon");
        startCor_Spawn15Sec = StartCoroutine("CO_Spawn15Sec");
    }

    void Update()
    {
        
    }

    IEnumerator CO_SpawnBalloon()
    {
        while (true)
        {
            ranX1 = Random.Range(-8.0f, -0.3f);
            ranX2 = Random.Range(0.3f, 8.0f);
            idx1 = Random.Range(0, 4);
            switch (idx1)
            {
                case 0:
                    BalloonWaterPool.Inst.Get(new Vector2(ranX2, -4));
                    break;
                case 1:
                    BalloonSunPool.Inst.Get(new Vector2(ranX1, -4));
                    break;
                case 2:
                    BalloonSeedPool.Inst.Get(new Vector2(ranX2, -4));
                    break;
                case 3:
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
            yield return new WaitForSeconds(15f);
            ranX3 = Random.Range(-8.0f, -0.3f);
            ranX4 = Random.Range(0.3f, 8.0f);
            idx2 = Random.Range(0, 2);
            switch (idx2)
            {
                case 0:
                    BalloonBeePool.Inst.Get(new Vector2(ranX3, -4));
                    break;
                case 1:
                    BalloonButterflyPool.Inst.Get(new Vector2(ranX4, -4));
                    break;
            }
        }
    }
}
