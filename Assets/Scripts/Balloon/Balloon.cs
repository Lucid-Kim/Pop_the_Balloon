using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject[] obj;
    [SerializeField] protected GameObject eff;
    protected int ranNum;
    float ranMoveX;
    float speed = 5;
    public virtual void Interact()
    {
        
    }

    protected virtual void Floating()
    {
        ranMoveX = Random.Range(-0.4f, 0.4f);
        transform.Translate(ranMoveX * Time.deltaTime * speed , 1f * Time.deltaTime * speed, 0);
    }

}
