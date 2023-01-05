using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour,Object_Interactable
{
    float ranMoveX;

    public virtual void Interact()
    {
        PopEffectPool.Inst.Get(this.gameObject.transform.position+Vector3.up);
    }

    protected virtual void Floating()
    {
        ranMoveX = Random.Range(-0.02f, 0.02f);
        transform.Translate(ranMoveX, 0.03f, 0);
    }

}
