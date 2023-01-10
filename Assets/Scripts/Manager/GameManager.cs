using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] Image readyImage;
    [SerializeField] GameObject balloonSpawner;
    [SerializeField] GameObject feverSpawner;
    GameObject targetBlooming;
    GameObject targetWithered;
    GameObject restoredBlooming;
    [SerializeField] Sprite witheredImage;
    [SerializeField] Sprite bloomingImage;
    [SerializeField] GameObject basicGrass;
    [SerializeField] GameObject endGrass;
    public Queue<GameObject> bloom = new Queue<GameObject>();
    public Queue<GameObject> witheredFlowerQueue = new Queue<GameObject>();
    public bool isGameover;
    bool isWithered;
    Coroutine withered;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(CO_ReadyOff());
    }
    private void Update()
    {
        if (isGameover == false)
        {
            //Debug.Log("withered ����" + isWithered);
            if ((UIManager.Inst.fertilizerSlider.value < 0.3f || UIManager.Inst.waterSlider.value < 0.3f || UIManager.Inst.sunSlider.value < 0.3f) && isWithered == false && bloom.Count != 0)
            {
                isWithered = true;
                targetBlooming = bloom.Dequeue();
                withered = StartCoroutine(nameof(CO_WitheredFlower));
            }
            //else if (UIManager.Inst.fertilizerSlider.value >= 0.3f & UIManager.Inst.waterSlider.value >= 0.3f & UIManager.Inst.sunSlider.value >= 0.3f && isWithered == true && witheredFlowerQueue.Count != 0)
            //{
            //    Debug.Log("������");
            //    StopCoroutine(withered);
            //    // �õ� �� -> ���� ������ ����
            //    targetWithered.SetActive(false);
            //    restoredBlooming = FlowerPool.Inst.Get(targetWithered.transform.position);  
            //    // ���� å���� ť�� �� �־��ֱ�
            //    bloom.Enqueue(restoredBlooming);
            //    //withered = null;
            //    isWithered = false;
                
            //    //���⼭
            //}
        }
    }
    public void EndGame()
    {
        Debug.Log("���� ��!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        basicGrass.SetActive(false);
        endGrass.SetActive(true);
        UIManager.Inst.GameoverOn();
        Debug.Log(witheredFlowerQueue.Count);
    }

    IEnumerator CO_ReadyOff()
    {
        yield return new WaitForSeconds(3.5f);
        readyImage.gameObject.SetActive(false);
        balloonSpawner.SetActive(true);
        timer.gameObject.SetActive(true);
    }


    IEnumerator CO_WitheredFlower()
    {
        
        Debug.Log("3�� ����");
        targetBlooming.gameObject.SetActive(false); // �ش� �� ������Ʈ ����
        targetWithered = WitheredPool.Inst.Get(targetBlooming.transform.position); // �� ��ġ�� �õ� �� ������Ʈ ����
        yield return new WaitForSeconds(3f);
        Debug.Log("3�� �� �õ���");
        WitheredPool.Inst.Release(targetWithered);
        isWithered = false;
    }

    //IEnumerator CO_RestoredFlower()
    //{

    //}

    public void SceneMove()
    {
        SceneManager.LoadScene("1.StartSCene");
    }

    
    // �ǹ� Ÿ�� ���� �Լ�
    public void FeverSpawnerOn()
    {
        balloonSpawner.SetActive(false);
        feverSpawner.SetActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    // �ǹ� Ÿ�� ���� �ڷ�ƾ
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        feverSpawner.SetActive(false);
        balloonSpawner.SetActive(true);
    }

}
