using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] GameObject [] blooming;

    /// <summary>
    /// �ٴڰ� �浹���� �� �Ǿ�� �� ���� �Լ�
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            float ranX = Random.Range(-8.0f, 8.0f);
            int idx = Random.Range(0, 3); // �� ���� ���� ����
            DictionaryPool.Inst.Destroy(this.gameObject);

            // �������� ������ �� ����
            GameObject thisBlooming = DictionaryPool.Inst.Instantiate(blooming[idx], new Vector2(ranX, collision.transform.position.y + 1), Quaternion.identity, DictionaryPool.Inst.transform); 
            GameManager.Inst.ListEnqueue(thisBlooming); // �Ǿ �� ����Ʈ �߰�
        }
    }

    
}
