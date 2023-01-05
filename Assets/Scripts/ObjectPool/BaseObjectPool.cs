using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectPool<T1, T2> : Singleton<BaseObjectPool<T1, GameObject>>
{
    Queue<GameObject> pool = new Queue<GameObject>();

    // ��ӹ޴� Ŭ�������� �������� �Ҵ��Ѵ�.
    protected virtual GameObject getPrefab()
    {
        return null;
    }

    // �������� �����Ѵ�.
    protected virtual GameObject Create()
    {
        GameObject obj = Instantiate(getPrefab());
        return obj;
    }

    // ����������� �������� pool���� �����´�.
    public virtual GameObject Get(Vector2 position)
    {
        GameObject obj = pool.Count == 0 ? Create() : pool.Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
        obj.transform.position = position;
        obj.transform.rotation = Quaternion.identity;
        return obj;
    }

    // Ǯ�� ȸ���Ѵ�.
    public virtual void Release(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
