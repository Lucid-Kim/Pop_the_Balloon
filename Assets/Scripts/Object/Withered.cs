using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Withered : MonoBehaviour
{
    GameObject restoredBlooming;

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Inst.fertilizerSlider.value >= 0.3f & UIManager.Inst.waterSlider.value >= 0.3f & UIManager.Inst.sunSlider.value >= 0.3f)
        {
            Debug.Log("�õ�ɾ� ���ض� ��!");
            // �õ� �� -> ���� ������ ����
            this.gameObject.SetActive(false);
            restoredBlooming = FlowerPool.Inst.Get(transform.position);
            // ���� å���� ť�� �� �־��ֱ�
            GameManager.Inst.ListEnqueue(restoredBlooming);
            Debug.Log(GameManager.Inst.bloom.Count);
        }
    }
}
