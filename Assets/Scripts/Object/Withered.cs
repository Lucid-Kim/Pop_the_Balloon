using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withered : MonoBehaviour
{
    GameObject restoredBlooming;
    [SerializeField] GameObject [] blooming;
    int ranNum;
    
    // Update is called once per frame
    void Update()
    {
        if (UIManager.Inst.fertilizerSlider.value >= 0.3f & UIManager.Inst.waterSlider.value >= 0.3f & UIManager.Inst.sunSlider.value >= 0.3f)
        {
            ranNum = Random.Range(0, 3);
            Debug.Log("�õ�ɾ� ���ض� ��!");
            // �õ� �� -> ���� ������ ����
            this.gameObject.SetActive(false);
            restoredBlooming = DictionaryPool.Inst.Instantiate(blooming[ranNum], transform.position,Quaternion.identity, DictionaryPool.Inst.transform);
            // ���� å���� ť�� �� �־��ֱ�
            GameManager.Inst.ListEnqueue(restoredBlooming);
            Debug.Log(GameManager.Inst.bloom.Count);
        }
    }
}
