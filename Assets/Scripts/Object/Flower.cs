using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] GameObject blooming;
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
            float ranX = Random.Range(-8.0f, 8.0f);
            FlowerPool.Inst.Release(this.gameObject);
            GameObject thisBlooming = Instantiate(blooming, new Vector2(ranX,collision.transform.position.y+1), Quaternion.identity);
            GameManager.Inst.bloom.Enqueue(thisBlooming);
            Debug.Log("ť�� �� ��" + GameManager.Inst.bloom.Count);
        }
    }

    
}
