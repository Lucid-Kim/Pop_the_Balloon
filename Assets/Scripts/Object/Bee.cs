using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject[] blooming; // 피어나는 꽃의 프리팹
    float deg; // 각도
    bool isStopped; // 그리는 것을 멈추기 위한 bool 값
    float speed = 500f; // 원을 그리는 속도
    Vector2 curPos; // 현재 좌표
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
    /// 원을 그리게 움직이는 모션
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
    /// 아래 구역에서 피어나는 꽃 생성 함수
    /// </summary>
    void CreateBlooming()
    {
        float ranX = Random.Range(-8.0f, 8.0f); // 생성 될 x좌표
        int ranIdx = Random.Range(0, 3);
        GameObject thisBlooming = Instantiate(blooming[ranIdx], new Vector2(ranX, -4), Quaternion.identity);
    }
}
