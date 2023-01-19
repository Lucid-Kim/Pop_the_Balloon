using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] balloonFlower; // 采 浅急甸 坷宏璃飘
    
    float ranX1;        // 1备开(哭率) 罚待 x谅钎
    float ranX2;        // 2备开(坷弗率) 罚待 x谅钎
    float centerX = 1f; // 吝居急阑 搓瘤 臼霸 急沥茄 x谅钎
    int ranNum1;        // 1备开(哭率) 积己瞪 采 浅急 牢郸胶
    int ranNum2;        // 2备开(坷弗率) 积己瞪 采 浅急 牢郸胶

    Coroutine feverTime;
    private void OnEnable()
    {
        feverTime = StartCoroutine(nameof(CO_FeverTime));
    }
    
    
    /// <summary>
    /// 采 浅急捞 瘤加利栏肺 积己
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_FeverTime()
    {
        while(true)
        {
            ranX1 = Random.Range(-8, -centerX);
            ranX2 = Random.Range(centerX, 8);
            ranNum1 = Random.Range(0, 2); // 哭率俊 积己瞪 采狼 辆幅
            ranNum2 = Random.Range(0, 2); // 坷弗率俊 积己瞪 采狼 辆幅
            
            DictionaryPool.Inst.Instantiate(balloonFlower[ranNum1], new Vector2(ranX1, -5), Quaternion.identity, DictionaryPool.Inst.transform); // 哭率 备开 采浅急 积己
            DictionaryPool.Inst.Instantiate(balloonFlower[ranNum2], new Vector2(ranX2, -5), Quaternion.identity, DictionaryPool.Inst.transform); // 坷弗率 备开 采浅急 积己
            yield return new WaitForSeconds(0.25f);
        }


    }


}
