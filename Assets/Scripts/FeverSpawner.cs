using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    float ranX1;
    float ranX2;
    float centerX = 1f;
    int idx;

    Coroutine feverTime;
    private void OnEnable()
    {
        feverTime = StartCoroutine(nameof(CO_FeverTime));
    }
    
    // 1���� 2���� ���� ����

    IEnumerator CO_FeverTime()
    {
        while(true)
        {
            ranX1 = Random.Range(-8, -centerX);
            ranX2 = Random.Range(centerX, 8);
            idx = Random.Range(0, 2);
            switch(idx)
            {
                case 0:
                    BalloonFlowerPool.Inst.Get(new Vector2(ranX1, -4));
                    break;
                case 1:
                    BalloonFlowerPool.Inst.Get(new Vector2(ranX2, -4));
                    break;
            }
            yield return new WaitForSeconds(0.25f);
        }


    }


}
