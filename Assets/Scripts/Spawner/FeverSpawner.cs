using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] balloonFlower; // �� ǳ���� ������Ʈ
    
    float ranX1;        // 1����(����) ���� x��ǥ
    float ranX2;        // 2����(������) ���� x��ǥ
    float centerX = 1f; // �߾Ӽ��� ���� �ʰ� ������ x��ǥ
    int ranNum1;        // 1����(����) ������ �� ǳ�� �ε���
    int ranNum2;        // 2����(������) ������ �� ǳ�� �ε���

    Coroutine feverTime;
    private void OnEnable()
    {
        feverTime = StartCoroutine(nameof(CO_FeverTime));
    }
    
    
    /// <summary>
    /// �� ǳ���� ���������� ����
    /// </summary>
    /// <returns></returns>
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
