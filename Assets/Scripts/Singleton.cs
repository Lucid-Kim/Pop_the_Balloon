using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Type�� �°� �̱����� ������ �� �ִ� ��ũ��Ʈ
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected Singleton() { }
    static T Instance;

    public static T Inst
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType(typeof(T)) as T;
                if (Instance == null)
                {
                    Instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }
            }
            return Instance;
        }
    }


}
