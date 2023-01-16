using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject balloon;
    float ranMoveX;
    float speed = 3;
    public virtual void Interact()
    {
        PopEffectPool.Inst.Get(this.gameObject.transform.position + Vector3.up);
    }

    protected virtual void Floating()
    {
        ranMoveX = Random.Range(-0.02f, 0.02f);
        transform.Translate(ranMoveX,1f * Time.deltaTime * speed, 0);
    }

}
