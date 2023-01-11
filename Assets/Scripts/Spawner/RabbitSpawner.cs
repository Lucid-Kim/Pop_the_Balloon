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
        yield return new WaitForSeconds(5f); // �䳢 ��� �ð�(30��)
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
            yield return new WaitForSeconds(10f); // �䳢 ��ȯ �ֱ�(20��)
        }
    }
}
