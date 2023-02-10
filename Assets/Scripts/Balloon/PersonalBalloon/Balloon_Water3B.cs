using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon_Water3B : Balloon
{
    TextMeshProUGUI scoreText;
    int addedScore = 15;
    private void Awake()
    {
        scoreText = obj[2].GetComponent<TextMeshProUGUI>();
    }
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

        GameManager.Inst.score += addedScore;
        // �� �Ѹ��� ȿ�� ����
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(9, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // ���� �ö󰡴� �ؽ�Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 2, 0)), Quaternion.identity, GameObject.Find("UI").transform);
        scoreText.text = "+" + addedScore;

        // UI �ؽ�Ʈ ���� ����
        UIManager.Inst.UpdateScore();
    }
}