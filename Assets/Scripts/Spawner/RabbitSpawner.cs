using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : Singleton<RabbitSpawner>
{
    public int idx = 0;
    Coroutine startCor_SpawnRabbit;
    [SerializeField] GameObject rabbit; // �䳢 ������Ʈ
    private void OnEnable()
    {
        startCor_SpawnRabbit = StartCoroutine(nameof(CO_SpawnRabbit));
    }

    /// <summary>
    /// �䳢 ����
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_SpawnRabbit()
    {
        yield return new WaitForSeconds(5f); // �䳢 ��� �ð�
        while (true)
        {
            if (GameManager.Inst.bloom.Count != 0)
            {
                idx = Random.Range(0, 2);
                switch (idx)
                {
                    case 0:
                        DictionaryPool.Inst.Instantiate(rabbit, new Vector2(-9, -4), Quaternion.identity, DictionaryPool.Inst.transform);
                        break;
                    case 1:
                        DictionaryPool.Inst.Instantiate(rabbit, new Vector2(9, -4), Quaternion.identity, DictionaryPool.Inst.transform);
                        break;
                }
                yield return new WaitForSeconds(10f); // �䳢 ��ȯ �ֱ�
            }
            else yield return null;
        }
    }
}
