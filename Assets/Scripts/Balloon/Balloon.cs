using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject balloonEffect; // ǳ���� ���� �� ������ ����Ʈ
    [SerializeField] protected GameObject effect; // ǳ���� Ư¡�� ���� ����Ʈ
    [SerializeField] protected GameObject scorePrefab; // ������ ��Ÿ����������
    [SerializeField] float speed = 5; // ǳ���� �ߴ� �ӵ�
    [SerializeField] protected int collaborationIdx; // ������� ������ ��Ÿ���� �ε���

    [SerializeField] Vector3 objPosition; // ������Ʈ�� ��ġ ������ �ʿ��� �� ����ϴ� ���� obj[1] �� ��ġ
    [SerializeField] Vector3 objRotation; // ������Ʈ�� ȸ�� ������ �ʿ��� �� ����ϴ� ���� obj[1] �� ȸ����

    [Header("���� Ȯ�ο�")]
    [SerializeField] protected bool isScored; // ���� ǥ�õǾ�� �ϴ��� Ȯ���ϴ� bool ��
    [SerializeField] protected int addedScore; // �߰��Ǵ� ����
    protected TextMeshProUGUI scoreText; // ������ ��Ÿ���� �ؽ�Ʈ
    protected float maxPosX = 9f; // ������ �� �� �ִ� �ִ� x��ǥ
    protected float centerPosX = 1f; // �߰��� ���� ��Ÿ���� x��ǥ
    
    protected Camera cam;    // 2���� ǳ���� ������ ��Ÿ���� �ؽ�Ʈ�� ��ũ�� ���������� �������� ���� ���� ķ
    int movedir = 0;

    private void OnEnable()
    {
        Floating();
    }
    public virtual void Interact()
    {
        float ranPosX = Random.Range(centerPosX, maxPosX);  // 2������ �����ϱ����� ���� X��ǥ
        float ranPosY = Random.Range(-3f, 2f); // 2������ �����ϱ����� ���� Y��ǥ
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // ǳ�� ������ ������Ʈ ����
        DictionaryPool.Inst.Instantiate(balloonEffect, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        SoundManager.Inst.PlaySFX("BalloonPopSFX");

        // ��������̸� 1���� ǳ���̶��
        if (GameDatas.Inst.mode == Mode.COLLABORATION && collaborationIdx == 1 && GameManager.Inst.Region2Spawned() == true)
        {
            // 2������ �ش��ϴ� ǳ�� ����
            DictionaryPool.Inst.Instantiate(effect, new Vector3(ranPosX, ranPosY, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
        // ��������̸� 2���� & ���θ�� ǳ���̶��
        else if (GameDatas.Inst.mode == Mode.PERSONAL || collaborationIdx == 2)
        {
            // 1�� ������Ʈ ��ġ�� ȸ���� ����
            GameObject obj1 = DictionaryPool.Inst.Instantiate(effect, new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            obj1.transform.position = objPosition;
            obj1.transform.rotation = Quaternion.Euler(objRotation);
            
            GameManager.Inst.Region2AddCount(-1);
        }

        if (isScored == true) // ���� �ؽ�Ʈ�� �־�� �Ѵٸ�
        {
            ShowScoreText();
        }
    }
    protected virtual void Update()
    {
        if (collaborationIdx == 1 || GameDatas.Inst.mode == Mode.PERSONAL)
        {
            transform.Translate(0, 1f * Time.deltaTime * speed, 0); // �����ϰ� �ö󰡰� ����
        }
    }

    protected virtual void Floating()
    {
        if (collaborationIdx == 1 || GameDatas.Inst.mode == Mode.PERSONAL)
        {
            StartCoroutine(nameof(CO_Floating));
        }
    }
    /// <summary>
    /// ǳ���� �������� �¿�� �����ϰ� �����̰� ����
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator CO_Floating()
    {
        while (transform.position.y < 6)
        {
            if (movedir == 0) // ������ ����
            {
                transform.Translate(0.3f * Time.deltaTime * speed, 0, 0);
                movedir = 1;
            }
            else // ���� ����
            {
                transform.Translate(-0.3f * Time.deltaTime * speed, 0, 0);
                movedir = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
        DictionaryPool.Inst.Release(this.gameObject);
    }

    /// <summary>
    /// ������ UI �ؽ�Ʈ�� �����ִ� �Լ�
    /// </summary>
    protected virtual void ShowScoreText()
    {
        // ���� �ö󰡴� �ؽ�Ʈ ����
        GameObject temp = DictionaryPool.Inst.Instantiate(scorePrefab, cam.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("UI").transform);
        scoreText = temp.GetComponent<TextMeshProUGUI>();
        if (addedScore >= 0)
        {
            scoreText.text = "+" + addedScore;
        }
        else
        {
            scoreText.text = addedScore.ToString();
            SoundManager.Inst.PlaySFX("BombSFX");
        }

        // ���ӸŴ������� �����ϴ� ���� �ø���
        GameManager.Inst.score += addedScore;
        // UI �ؽ�Ʈ ���� ����
        UIManager.Inst.UpdateScore();
    }
}
