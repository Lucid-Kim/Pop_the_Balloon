using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            DictionaryPool.Inst.Destroy(this.gameObject);
            // 여기에 물 슬라이더 올라가는 것 하면 됨
        }
    }
}
