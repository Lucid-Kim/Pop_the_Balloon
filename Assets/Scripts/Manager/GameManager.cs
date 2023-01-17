using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("게임시작")]
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] Image readyImage;
    [Header("스포너")]
    [SerializeField] GameObject balloonSpawner;
    [SerializeField] GameObject feverSpawner;
    [SerializeField] GameObject rabbitSpawner;
    [SerializeField] TextMeshProUGUI feverText;
    [SerializeField] GameObject witheredPrefab;
    GameObject targetBlooming;
    GameObject targetWithered;
    GameObject restoredBlooming;
    [SerializeField] Sprite witheredImage;
    [SerializeField] Sprite bloomingImage;
    public List<GameObject> bloom = new List<GameObject>();
    public Queue<GameObject> witheredFlowerQueue = new Queue<GameObject>();
    public bool isGameover;
    bool isWithered;
    public bool isFeverTime;
    Coroutine withered;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(nameof(CO_ReadyOff));
    }
    private void Update()
    {
        if (isGameover == false)
        {
            //Debug.Log("withered 상태" + isWithered);
            if ((UIManager.Inst.fertilizerSlider.value < 0.3f || UIManager.Inst.waterSlider.value < 0.3f || UIManager.Inst.sunSlider.value < 0.3f) && isWithered == false && bloom.Count != 0)
            {
                isWithered = true;
                targetBlooming = ListDequeue();
                withered = StartCoroutine(nameof(CO_WitheredFlower));
            }
            //else if (UIManager.Inst.fertilizerSlider.value >= 0.3f & UIManager.Inst.waterSlider.value >= 0.3f & UIManager.Inst.sunSlider.value >= 0.3f && isWithered == true && witheredFlowerQueue.Count != 0)
            //{
            //    Debug.Log("복구해");
            //    StopCoroutine(withered);
            //    // 시든 꽃 -> 원래 꽃으로 변경
            //    targetWithered.SetActive(false);
            //    restoredBlooming = FlowerPool.Inst.Get(targetWithered.transform.position);  
            //    // 점수 책정할 큐에 꽃 넣어주기
            //    bloom.Enqueue(restoredBlooming);
            //    //withered = null;
            //    isWithered = false;
                
            //    //여기서
            //}
        }
    }
    public void EndGame()
    {
        Debug.Log("게임 끝!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        rabbitSpawner.SetActive(false);
        UIManager.Inst.GameoverOn();
        Debug.Log(witheredFlowerQueue.Count);
    }

    IEnumerator CO_ReadyOff()
    {
        yield return new WaitForSeconds(3.5f);
        readyImage.gameObject.SetActive(false);
        balloonSpawner.SetActive(true);
        rabbitSpawner.SetActive(true);
        timer.gameObject.SetActive(true);

    }


    IEnumerator CO_WitheredFlower()
    {
        
        //Debug.Log("3초 시작");
        targetBlooming.gameObject.SetActive(false); // 해당 꽃 오브젝트 제거
        targetWithered = DictionaryPool.Inst.Instantiate(witheredPrefab, targetBlooming.transform.position, Quaternion.identity, DictionaryPool.Inst.transform); // 그 위치에 시든 꽃 오브젝트 생성
        yield return new WaitForSeconds(3f);
        //Debug.Log("3초 끝 시들어라");
        DictionaryPool.Inst.Destroy(targetWithered);
        isWithered = false;
    }

    //IEnumerator CO_RestoredFlower()
    //{

    //}

    public void SceneMove()
    {
        SceneManager.LoadScene("1.StartSCene");
    }

    
    // 피버 타임 적용 함수
    public void FeverSpawnerOn()
    {
        isFeverTime = true;
        balloonSpawner.SetActive(false);
        feverSpawner.SetActive(true);
        feverText.gameObject.SetActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    // 피버 타임 해제 코루틴
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        feverText.gameObject.SetActive(false);
        feverSpawner.SetActive(false);
        isFeverTime = false;
        balloonSpawner.SetActive(true);
    }

    public void ListEnqueue(GameObject obj)
    {
        bloom.Add(obj);
        Debug.Log("bloom 갯수" + bloom.Count);
    }

    public GameObject ListDequeue()
    {
        GameObject selectObj = bloom[0];
        bloom.RemoveAt(0);
        
        return selectObj;
    }
}
