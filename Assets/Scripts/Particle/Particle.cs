using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    /// <summary>
    /// delayTime 이후에 이펙트가 사라지는 함수
    /// </summary>
    /// <param name="delayTime"></param>
    protected virtual void DelayRelease(float delayTime)
    {
        Invoke(nameof(Release), delayTime);
    }


    protected virtual void Release()
    {
        DictionaryPool.Inst.Destroy(this.gameObject);
    }

}
