using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] balloonFlower; // �� ǳ���� ������Ʈ
    
    float ranX1;        // 2����(������) ���� x��ǥ
    float ranY;         // 2����(������) ���� y��ǥ
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
            ranX1 = Random.Range(centerX, 8);
            ranY = Random.Range(-1f, 3f);
            ranNum1 = Random.Range(0, 5); // �����ʿ� ������ ���� ����
            
            DictionaryPool.Inst.Instantiate(balloonFlower[ranNum1], new Vector2(ranX1, ranY), Quaternion.identity, DictionaryPool.Inst.transform); // ������ ���� ��ǳ�� ����
            
            yield return new WaitForSeconds(0.25f);
        }


    }


}
