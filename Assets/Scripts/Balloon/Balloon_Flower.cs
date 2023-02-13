using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon_Flower : Balloon
{
    [SerializeField] GameObject[] flowerPrefab; // 터치시 나타나는 오브젝트(예: 2구역 꽃풍선, 3구역 꽃)
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
        float ranPosY = Random.Range(-4.5f, 2f); // 2구역에 생성하기위한 랜덤 Y좌표
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // 풍선 터지는 오브젝트 생성
        DictionaryPool.Inst.Instantiate(balloonEffect, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // 협동모드 1구역 풍선이라면
        if (GameDatas.Inst.mode == Mode.COLLABORATION && collaborationIdx == 1 && GameManager.Inst.Region2Spawned() == true)
        {
            float ranPosX = Random.Range(centerPosX, maxPosX); // 2구역에 생성하기위한 랜덤 X좌표
            int flowerIdx = Random.Range(0, flowerPrefab.Length);
            // 2구역에 꽃풍선 생성
            DictionaryPool.Inst.Instantiate(flowerPrefab[flowerIdx], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
        // 협동모드이며 2구역 또는 개인 풍선이라면
        else if (GameDatas.Inst.mode == Mode.PERSONAL || collaborationIdx == 2)
        {
            float ranPosX = Random.Range(-maxPosX, maxPosX);
            // 꽃 생성 (현재는 랜덤생성인데 기획에서 내용 바뀌면 위치 바꿔줘야함) ///////////
            int flowerIdx = Random.Range(1, flowerPrefab.Length);
            DictionaryPool.Inst.Instantiate(flowerPrefab[flowerIdx], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(-1);
        }
        if (isScored == true) // 점수 텍스트가 있어야 한다면
        {
            base.ShowScoreText();
        }
    }
}
