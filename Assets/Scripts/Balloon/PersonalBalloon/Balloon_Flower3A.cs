using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balloon_Flower3A : Balloon
{
    TextMeshProUGUI scoreText;
    int addedScore = 10;
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
        // ���ӸŴ������� �����ϴ� ���� �ø���
        GameManager.Inst.score += addedScore;
        
        // �� ���� (����� ���������ε� ��ȹ���� ���� �ٲ�� ��ġ �ٲ������)
        DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        
        // ���� �ö󰡴� �ؽ�Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);
        scoreText.text = "+" + addedScore;

        // UI �ؽ�Ʈ ���� ����
        UIManager.Inst.UpdateScore();
    }
}
