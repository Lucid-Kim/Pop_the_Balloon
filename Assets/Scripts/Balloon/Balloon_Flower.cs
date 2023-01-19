using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Flower : Balloon
{
    public int ranBloomingNum;
    private void OnEnable()
    {
        Floating();
    }
    protected override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();
        // ²É Á¾·ù ÀÎµ¦½º ¼³Á¤
        ranBloomingNum = Random.Range(0, 3);
        DictionaryPool.Inst.Destroy(this.gameObject);

        // ²É 3Á¾·ù Áß ·£´ýÇÏ°Ô »ý¼º
        DictionaryPool.Inst.Instantiate(obj[ranBloomingNum], this.gameObject.transform.position, Quaternion.identity, DictionaryPool.Inst.transform);

        // ²É Ç³¼± ÅÍÄ¡ÀÌÆåÆ® »ý¼º
        DictionaryPool.Inst.Instantiate(obj[3], this.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, DictionaryPool.Inst.transform); 
    }

    
}
