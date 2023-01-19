using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject[] blooming; // �Ǿ�� ���� ������
    float deg; // ����
    bool isStopped; // �׸��� ���� ���߱� ���� bool ��
    float speed = 500f; // ���� �׸��� �ӵ�
    Vector2 curPos; // ���� ��ǥ
    private void OnEnable()
    {
        curPos = transform.position;
    }
    void Update()
    {
        if (isStopped == false)
        {
            CircularMotion();
        }
    }


    /// <summary>
    /// ���� �׸��� �����̴� ���
    /// </summary>
    void CircularMotion()
    {
        deg += Time.deltaTime * speed;
        if (deg < 360)
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = Mathf.Cos(rad);
            var y = Mathf.Sin(rad);
            transform.position = curPos + new Vector2(-x, y);
        }
        else
        {
            deg = 0;
            Destroy(this.gameObject);
            CreateBlooming();
            isStopped = true;
        }
    }

    /// <summary>
    /// �Ʒ� �������� �Ǿ�� �� ���� �Լ�
    /// </summary>
    void CreateBlooming()
    {
        float ranX = Random.Range(-8.0f, 8.0f); // ���� �� x��ǥ
        int ranIdx = Random.Range(0, 3);
        GameObject thisBlooming = Instantiate(blooming[ranIdx], new Vector2(ranX, -4), Quaternion.identity);
        GameManager.Inst.ListEnqueue(thisBlooming); // �Ǿ ���� ī��Ʈ �ϱ����Ͽ� ����Ʈ�� �߰�
    }
}
