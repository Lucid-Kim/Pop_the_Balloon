using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    float ranX1;
    float ranX2;
    float centerX = 1f;
    

    Coroutine feverTime;
    private void OnEnable()
    {
        feverTime = StartCoroutine(nameof(CO_FeverTime));
    }
    
    // 1备开 2备开 公茄 积己

    IEnumerator CO_FeverTime()
    {
        while(true)
        {
            ranX1 = Random.Range(-8, -centerX);
            ranX2 = Random.Range(centerX, 8);
            
            BalloonFlowerPool.Inst.Get(new Vector2(ranX1, -5));
            BalloonFlowerPool.Inst.Get(new Vector2(ranX2, -5));
            yield return new WaitForSeconds(0.25f);
        }


    }


}
