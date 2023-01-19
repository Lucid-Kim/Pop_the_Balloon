using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    /// <summary>
    /// delayTime ���Ŀ� ����Ʈ�� ������� �Լ�
    /// </summary>
    /// <param name="delayTime"></param>
    protected virtual void DelayRelease(float delayTime)
    {
        Invoke(nameof(Release), delayTime);
    }


    protected virtual void Release()
    {
        DictionaryPool.Inst.Release(this.gameObject);
    }

}
