using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] GameObject [] blooming;
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
            int idx = Random.Range(0, 3); // ²É Á¾·ù ·£´ý ¼³Á¤
            DictionaryPool.Inst.Destroy(this.gameObject);
            GameObject thisBlooming = DictionaryPool.Inst.Instantiate(blooming[idx], new Vector2(ranX, collision.transform.position.y + 1), Quaternion.identity, DictionaryPool.Inst.transform); // ·£´ýÀ¸·Î ¼³Á¤µÈ ²É »ý¼º
            GameManager.Inst.ListEnqueue(thisBlooming); // ÇÇ¾î³­ ²É ¸®½ºÆ® Ãß°¡
            Debug.Log("Å¥ÀÇ °¹ ¼ö" + GameManager.Inst.bloom.Count);
        }
    }

    
}
