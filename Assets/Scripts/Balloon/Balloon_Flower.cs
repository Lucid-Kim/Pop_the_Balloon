using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon_Flower : Balloon
{
    [SerializeField] GameObject[] flowerPrefab; // ��ġ�� ��Ÿ���� ������Ʈ(��: 2���� ��ǳ��, 3���� ��)
    private void OnEnable()
    {
        base.Floating();
    }

    protected override void Update()
    {
        base.Update();
    }
    // Update is called once per frame
    

    public override void Interact()
    {
        float ranPosY = Random.Range(-4.5f, 2f); // 2������ �����ϱ����� ���� Y��ǥ
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // ǳ�� ������ ������Ʈ ����
        DictionaryPool.Inst.Instantiate(balloonEffect, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // ������� 1���� ǳ���̶��
        if (GameDatas.Inst.mode == Mode.COLLABORATION && collaborationIdx == 1 && GameManager.Inst.Region2Spawned() == true)
        {
            float ranPosX = Random.Range(centerPosX, maxPosX); // 2������ �����ϱ����� ���� X��ǥ
            int flowerIdx = Random.Range(0, flowerPrefab.Length);
            // 2������ ��ǳ�� ����
            DictionaryPool.Inst.Instantiate(flowerPrefab[flowerIdx], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
        // ��������̸� 2���� �Ǵ� ���� ǳ���̶��
        else if (GameDatas.Inst.mode == Mode.PERSONAL || collaborationIdx == 2)
        {
            float ranPosX = Random.Range(-maxPosX, maxPosX);
            // �� ���� (����� ���������ε� ��ȹ���� ���� �ٲ�� ��ġ �ٲ������) ///////////
            int flowerIdx = Random.Range(1, flowerPrefab.Length);
            DictionaryPool.Inst.Instantiate(flowerPrefab[flowerIdx], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(-1);
        }
        if (isScored == true) // ���� �ؽ�Ʈ�� �־�� �Ѵٸ�
        {
            base.ShowScoreText();
        }
    }
}
