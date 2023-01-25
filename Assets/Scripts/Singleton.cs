using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Type에 맞게 싱글톤을 적용할 수 있는 스크립트
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T instance = null;
    static private object _lock = new object();
    static private bool applicationQuitting = false;

    static public T Inst
    {
        get
        {
            if (applicationQuitting)
            {
                return null;
            }

            if (instance == null)
            {
                instance = FindObjectOfType<T>(typeof(T) as T);
                Debug.Log(instance);

                if (instance == null)
                {
                    lock (_lock)
                    {
                        GameObject instObj = new(typeof(T).ToString(), typeof(T));
                        instance = instObj.GetComponent<T>();
                    }
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (FindObjectOfType<T>(typeof(T) as T).gameObject != this.gameObject) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        applicationQuitting = true;
    }

}
