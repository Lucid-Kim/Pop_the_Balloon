using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] GameObject blooming;
    float deg;
    bool isStopped;
    float speed = 500f;
    Vector2 curPos;
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

    void CreateBlooming()
    {
        float ranX = Random.Range(-8.0f, 8.0f);
        GameObject thisBlooming = Instantiate(blooming, new Vector2(ranX, -4), Quaternion.identity);
        GameManager.Inst.ListEnqueue(thisBlooming);
    }
}
