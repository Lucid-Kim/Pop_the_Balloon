using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour, Object_Interactable
{
    [SerializeField] AnimationCurve curveMove_Y;
    [SerializeField] float period;
    [SerializeField] GameObject butterflyEffect;
    float posX;
    float speed = 3.5f;
    float curTime;

    private void Start()
    {
        SoundManager.Inst.PlaySFX("ButterflySFX");
    }
    void Update()
    {
        if (transform.position.x <= 9)
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
    // ���� ��ġ���� ��
    public void Interact()
    {
        Instantiate(butterflyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        // �ǹ�Ÿ�� ����
        GameManager.Inst.FeverSpawnerOn();
    }

}
