using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("���ӽ���")]
    [SerializeField] TextMeshProUGUI timer; // ���� �ð��� ��Ÿ���� Ÿ�̸�
    [SerializeField] Image readyImage; // �غ� �ð��� ��Ÿ���� �̹���
    [Header("������")]
    [SerializeField] GameObject balloonSpawner; // ǳ�� ������
    [SerializeField] GameObject feverSpawner; // �ǹ�Ÿ�� ������
    [SerializeField] GameObject rabbitSpawner; // �䳢 ������
    [SerializeField] GameObject witheredPrefab; // �õ� �� ������

    public List<GameObject> bloom = new List<GameObject>(); // ���ھ� ������ ���� �Ǿ��ִ� �� ����Ʈ
    
    GameObject targetBlooming; // bloom ����Ʈ���� ���� ���� �߰��� �Ǿ��ִ� ��(�õ� ������ ���ϱ� ���� ����)
    GameObject targetWithered; // ���� �õ�� 3�ʵڿ� ������� �ϱ� ���� ����
    
    public bool isGameover; // ���� ���Ḧ ��Ÿ���� bool ��
    bool isWithered; // ���� �õ��� ��Ÿ���� bool ��
    public bool isFeverTime; // �ǹ�Ÿ���� ��Ÿ���� bool ��
    Coroutine withered; // ���� �õ�� ����� �ڷ�ƾ ����
    
    void Start()
    {
        StartCoroutine(nameof(CO_ReadyOff));
    }
    private void Update()
    {
        if (isGameover == false)
        {
            // �����̴� �� 3�� �߿��� 1���� 30�ۼ�Ʈ ������ �������� ���� �õ�
            if ((UIManager.Inst.fertilizerSlider.value < 0.3f || UIManager.Inst.waterSlider.value < 0.3f || UIManager.Inst.sunSlider.value < 0.3f) && isWithered == false && bloom.Count != 0)
            {
                isWithered = true;
                targetBlooming = ListDequeue();
                withered = StartCoroutine(nameof(CO_WitheredFlower));
            }
        }
    }
    // ���� ����� ���� �Ǵ� �Լ�
    public void EndGame()
    {
        Debug.Log("���� ��!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        rabbitSpawner.SetActive(false);
        UIManager.Inst.GameoverOn();
    }
    // 3���� �غ� �ð��� ���Ŀ� ������ ���۵ǰ� �ϴ� �ڷ�ƾ
    IEnumerator CO_ReadyOff()
    {
        yield return new WaitForSeconds(3.5f);
        readyImage.gameObject.SetActive(false);
        balloonSpawner.SetActive(true);
        rabbitSpawner.SetActive(true);
        timer.gameObject.SetActive(true);

    }

    // ���� �õ�� ����� �ڷ�ƾ
    IEnumerator CO_WitheredFlower()
    {
        
        //Debug.Log("3�� ����");
        targetBlooming.gameObject.SetActive(false); // �ش� �� ������Ʈ ����
        targetWithered = DictionaryPool.Inst.Instantiate(witheredPrefab, targetBlooming.transform.position, Quaternion.identity, DictionaryPool.Inst.transform); // �� ��ġ�� �õ� �� ������Ʈ ����
        yield return new WaitForSeconds(3f);
        //Debug.Log("3�� �� �õ���");
        DictionaryPool.Inst.Destroy(targetWithered); // �õ� �� ������Ʈ ����
        isWithered = false;
    }

    // �ǹ� Ÿ�� ���� �Լ�
    public void FeverSpawnerOn()
    {
        isFeverTime = true;
        balloonSpawner.SetActive(false);
        feverSpawner.SetActive(true);
        UIManager.Inst.feverText.gameObject.SetActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    // �ǹ� Ÿ�� ���� �ڷ�ƾ
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Inst.feverText.gameObject.SetActive(false);
        feverSpawner.SetActive(false);
        isFeverTime = false;
        balloonSpawner.SetActive(true);
    }

    // ���ھ� ������ ���� �Ǿ��ִ� �� ����Ʈ�� �߰��ϴ� �Լ�
    public void ListEnqueue(GameObject obj)
    {
        bloom.Add(obj);
    }

    // �Ǿ��ִ� �� ����Ʈ���� ���� ���� �� ���� �������� �Լ�
    public GameObject ListDequeue()
    {
        GameObject selectObj = bloom[0];
        bloom.RemoveAt(0);
        return selectObj;
    }
}
