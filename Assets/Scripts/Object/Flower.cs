using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] GameObject flowerEffect;
    void Start()
    {
        DictionaryPool.Inst.Instantiate(flowerEffect, transform.position, Quaternion.identity, DictionaryPool.Inst.transform);
    }

}
