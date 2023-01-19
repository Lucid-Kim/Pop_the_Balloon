using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withered : MonoBehaviour
{
    GameObject restoredBlooming;
    [SerializeField] GameObject [] blooming;
    int ranNum;
    
    void Update()
    {
        if (UIManager.Inst.fertilizerSlider.value >= 0.3f & UIManager.Inst.waterSlider.value >= 0.3f & UIManager.Inst.sunSlider.value >= 0.3f)
        {
            ranNum = Random.Range(0, 3);
            
            // 시든 꽃 -> 원래 꽃으로 변경
            this.gameObject.SetActive(false);

            // 시든 꽃 위치에서 피어난 꽃 
            restoredBlooming = DictionaryPool.Inst.Instantiate(blooming[ranNum], transform.position,Quaternion.identity, DictionaryPool.Inst.transform);
            // 점수 책정할 큐에 꽃 넣어주기
            GameManager.Inst.ListEnqueue(restoredBlooming);
            
        }
    }
}
