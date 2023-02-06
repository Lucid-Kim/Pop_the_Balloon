using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour, Object_Interactable
{
    [SerializeField] AnimationCurve curveMove_Y;
    [SerializeField] float period;
    float posX;
    float speed = 3.5f;
    float curTime;
    

    void Update()
    {
        if (transform.position.x <= 8)
        {
            posX = transform.position.x + Time.deltaTime * speed;
            curTime += Time.deltaTime;
            if (curTime >= period)
            {
                curTime -= curTime;
            }
            float yValue = curveMove_Y.Evaluate(curTime);
            transform.position = new Vector3(posX, yValue, 0);
        }
        else Destroy(gameObject);
    }
    // 나비를 터치했을 때
    public void Interact()
    {
        Destroy(gameObject);

        // 피버타임 시작
        GameManager.Inst.FeverSpawnerOn();
    }

}
