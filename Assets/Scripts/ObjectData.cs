using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public string name;

    public ObjectData(string[] datas)
    {
        this.name = datas[0];
    }
}
