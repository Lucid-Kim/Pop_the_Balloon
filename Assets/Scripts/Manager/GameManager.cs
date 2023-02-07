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
    [SerializeField] GameObject balloonSpawner; // ������� ǳ�� ������
    [SerializeField] GameObject personalSpawner; // ���θ�� ǳ�� ������
    [SerializeField] GameObject feverSpawner; // �ǹ�Ÿ�� ������
    [SerializeField] GameObject witheredPrefab; // �õ� �� ������
    int region2Count; // 2���� ǳ�� ����

    public List<GameObject> bloom = new List<GameObject>(); // ���ھ� ������ ���� �Ǿ��ִ� �� ����Ʈ
    public int score; // �ǽð� ������ ���� ������ ��Ÿ���� ����
    GameObject targetBlooming; // bloom ����Ʈ���� ���� ���� �߰��� �Ǿ��ִ� ��(�õ� ������ ���ϱ� ���� ����)
    GameObject targetWithered; // ���� �õ�� 3�ʵڿ� ������� �ϱ� ���� ����
    
    public bool isGameover; // ���� ���Ḧ ��Ÿ���� bool ��
    bool isWithered; // ���� �õ��� ��Ÿ���� bool ��
    public bool isFeverTime; // �ǹ�Ÿ���� ��Ÿ���� bool ��
    Coroutine withered; // ���� �õ�� ����� �ڷ�ƾ ����

    
    private void OnEnable()
    {
        StartCoroutine(nameof(CO_ReadyOff));
        
    }
    
    private void Update()
    {
        //if (isGameover == false)
        //{
        //    // �����̴� �� 3�� �߿��� 1���� 30�ۼ�Ʈ ������ �������� ���� �õ�
        //    if ((UIManager.Inst.fertilizerSlider.value < 0.3f || UIManager.Inst.waterSlider.value < 0.3f || UIManager.Inst.sunSlider.value < 0.3f) && isWithered == false && bloom.Count != 0)
        //    {
        //        isWithered = true;
        //        targetBlooming = ListDequeue();
        //        withered = StartCoroutine(nameof(CO_WitheredFlower));
        //    }
        //}
    }
    /// <summary>
    /// ���� ����� ���� �Ǵ� �Լ�
    /// </summary>
    public void EndGame()
    {
        Debug.Log("���� ��!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        UIManager.Inst.GameoverOn();
    }

    /// <summary>
    /// 3���� �غ� �ð��� ���Ŀ� ������ ���۵ǰ� �ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_ReadyOff()
    {
        Debug.Log("���� ����!");
        yield return new WaitForSeconds(3.5f);
        Debug.Log("3�� ��");
        readyImage.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);

        switch(GameDatas.Inst.mode)
        {
            case Mode.PERSONAL:
                personalSpawner.SetActive(true);
                break;
            case Mode.COLLABORATION:
                balloonSpawner.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// ���� �õ�� ����� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    //IEnumerator CO_WitheredFlower()
    //{
        
    //    //Debug.Log("3�� ����");
    //    targetBlooming.gameObject.SetActive(false); // �ش� �� ������Ʈ ����
    //    targetWithered = DictionaryPool.Inst.Instantiate(witheredPrefab, targetBlooming.transform.position, Quaternion.identity, DictionaryPool.Inst.transform); // �� ��ġ�� �õ� �� ������Ʈ ����
    //    yield return new WaitForSeconds(3f);
    //    //Debug.Log("3�� �� �õ���");
    //    DictionaryPool.Inst.Release(targetWithered); // �õ� �� ������Ʈ ����
    //    isWithered = false;
    //}

    /// <summary>
    /// �ǹ� Ÿ�� ���� �Լ�
    /// </summary>
    public void FeverSpawnerOn()
    {
        isFeverTime = true;
        balloonSpawner.SetActive(false);
        feverSpawner.SetActive(true);
        UIManager.Inst.FeverTextActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    /// <summary>
    /// �ǹ� Ÿ�� ���� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Inst.FeverTextActive(false);
        feverSpawner.SetActive(false);
        isFeverTime = false;
        balloonSpawner.SetActive(true);
    }

    /// <summary>
    /// ���ھ� ������ ���� �Ǿ��ִ� �� ����Ʈ�� �߰��ϴ� �Լ�
    /// </summary>
    /// <param name="obj"></param>
    public void ListEnqueue(GameObject obj)
    {
        bloom.Add(obj);
    }

    /// <summary>
    /// �Ǿ��ִ� �� ����Ʈ���� ���� ���� �� ���� �������� �Լ�
    /// </summary>
    /// <returns></returns>
    public GameObject ListDequeue()
    {
        GameObject selectObj = bloom[0];
        bloom.RemoveAt(0);
        return selectObj;
    }

    /// <summary>
    /// 2���� ǳ���� ������ �߰��ϴ� �Լ�
    /// </summary>
    /// <param name="num"></param>
    public void Region2AddCount(int num)
    {
        region2Count += num;
    }

    /// <summary>
    /// 2������ ǳ���� �����ص� �Ǵ��� �ľ��ϴ� bool ��
    /// </summary>
    /// <returns></returns>
    public bool Region2Spawned()
    {
        if (region2Count < 8) return true;
        else return false;
    }
    public void Restart()
    {
        DictionaryPool.Inst.DestroyMySelp();
        SceneManager.LoadScene("1.StartScene");
    }

}
