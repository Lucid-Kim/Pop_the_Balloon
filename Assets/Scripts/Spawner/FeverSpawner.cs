using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] balloonFlower;
    
    float ranX1;
    float ranX2;
    float centerX = 1f;
    int ranNum1;
    int ranNum2;

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
            ranNum1 = Random.Range(0, 2); // ���ʿ� ������ ���� ����
            ranNum2 = Random.Range(0, 2); // �����ʿ� ������ ���� ����
            
            DictionaryPool.Inst.Instantiate(balloonFlower[ranNum1], new Vector2(ranX1, -5), Quaternion.identity, DictionaryPool.Inst.transform); // ���� ���� ��ǳ�� ����
            DictionaryPool.Inst.Instantiate(balloonFlower[ranNum2], new Vector2(ranX2, -5), Quaternion.identity, DictionaryPool.Inst.transform); // ������ ���� ��ǳ�� ����
            yield return new WaitForSeconds(0.25f);
        }


    }


}
