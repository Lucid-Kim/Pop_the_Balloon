using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject[] obj; // ǳ�������� ����ϴ� ����Ʈ�� �߰��Ǵ� ������Ʈ
    [SerializeField] float speed = 5; // ǳ���� �ߴ� �ӵ�
    [SerializeField] int collaborationIdx; // ������� ������ ��Ÿ���� �ε���

    [SerializeField] bool isFlowered;     // ǳ���� �� ǳ������ Ȯ���ϴ� bool ��
    [SerializeField] Vector3 objPosition; // ������Ʈ�� ��ġ ������ �ʿ��� �� ����ϴ� ����
    [SerializeField] Vector3 objRotation; // ������Ʈ�� ȸ�� ������ �ʿ��� �� ����ϴ� ����

    [Header("���� Ȯ�ο�")]
    [SerializeField] bool isScored; // ���� ǥ�õǾ�� �ϴ��� Ȯ���ϴ� bool ��
    [SerializeField] int addedScore; // �߰��Ǵ� ����
    TextMeshProUGUI scoreText; // 


    int balloonIdx;          // 1������ �����Ǵ� ǳ���� �ε���
    protected float ranPosX; // 2������ �����ϱ����� ���� X��ǥ
    protected float ranPosY; // 2������ �����ϱ����� ���� Y��ǥ
    protected Camera cam;    // 2���� ǳ���� ������ ��Ÿ���� �ؽ�Ʈ�� ��ũ�� ���������� �������� ���� ���� ķ

    int movedir = 0;
    private void OnEnable()
    {
        Floating();
    }
    public virtual void Interact()
    {
        ranPosX = Random.Range(1f, 8f);
        ranPosY = Random.Range(-4.5f, 2f);
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // ǳ�� ������ ������Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // ��������̸� 1���� ǳ���̶��
        if (GameDatas.Inst.mode == Mode.COLLABORATION && collaborationIdx == 1 && GameManager.Inst.Region2Spawned() == true)
        {
            if (isFlowered == true)
            {
                balloonIdx = Random.Range(1, 6);
                // 2������ ��ǳ�� ����
                DictionaryPool.Inst.Instantiate(obj[balloonIdx], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            }
            else
            {
                // 2������ �ش��ϴ� ǳ�� ����
                DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, ranPosY, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            }
            GameManager.Inst.Region2AddCount(1);
        }
        // ��������̸� 2���� & ���θ�� ǳ���̶��
        else
        {
            if (isFlowered == true)
            {
                ranPosX = Random.Range(-8f, 8f);
                // �� ���� (����� ���������ε� ��ȹ���� ���� �ٲ�� ��ġ �ٲ������) ///////////
                DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            }
            else
            {
                // 1�� ������Ʈ ��ġ�� ȸ���� ����
                GameObject obj1 = DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
                obj1.transform.position = objPosition;
                obj1.transform.rotation = Quaternion.Euler(objRotation);
            }
            GameManager.Inst.Region2AddCount(-1);
        }

        if (isScored == true) // ���� �ؽ�Ʈ�� �־�� �Ѵٸ�
        {
            // ���� �ö󰡴� �ؽ�Ʈ ����
            GameObject temp = DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);
            scoreText = temp.GetComponent<TextMeshProUGUI>();
            if (addedScore >= 0)
            {
                scoreText.text = "+" + addedScore;
            }
            else scoreText.text = addedScore.ToString();
            // ���ӸŴ������� �����ϴ� ���� �ø���
            GameManager.Inst.score += addedScore;
            // UI �ؽ�Ʈ ���� ����
            UIManager.Inst.UpdateScore();
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

}
