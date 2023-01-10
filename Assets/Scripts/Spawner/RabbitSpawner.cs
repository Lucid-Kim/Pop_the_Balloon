using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : Singleton<RabbitSpawner>
{
    public int idx = 0;
    Coroutine startCor_SpawnRabbit;
    private void OnEnable()
    {
        startCor_SpawnRabbit = StartCoroutine(nameof(CO_SpawnRabbit));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CO_SpawnRabbit()
    {
        yield return new WaitForSeconds(3f); // 토끼 대기 시간(30초)
        while (true)
        {
            idx = Random.Range(0, 2);
            switch (idx)
            {
                case 0:
                    RabbitPool.Inst.Get(new Vector2(-9, -4));
                    break;
                case 1:
                    RabbitPool.Inst.Get(new Vector2(9, -4));
                    break;
            }
            yield return new WaitForSeconds(2f); // 토끼 소환 주기(20초)
        }
    }
}
