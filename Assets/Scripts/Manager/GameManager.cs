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
            //Debug.Log("withered 상태" + isWithered);
            if ((UIManager.Inst.fertilizerSlider.value < 0.3f || UIManager.Inst.waterSlider.value < 0.3f || UIManager.Inst.sunSlider.value < 0.3f) && isWithered == false && bloom.Count != 0)
            {
                isWithered = true;
                targetBlooming = bloom.Dequeue();
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
        
        Debug.Log("3초 시작");
        targetBlooming.gameObject.SetActive(false); // 해당 꽃 오브젝트 제거
        targetWithered = WitheredPool.Inst.Get(targetBlooming.transform.position); // 그 위치에 시든 꽃 오브젝트 생성
        yield return new WaitForSeconds(3f);
        Debug.Log("3초 끝 시들어라");
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

    
    // 피버 타임 적용 함수
    public void FeverSpawnerOn()
    {
        balloonSpawner.SetActive(false);
        feverSpawner.SetActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    // 피버 타임 해제 코루틴
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        feverSpawner.SetActive(false);
        balloonSpawner.SetActive(true);
    }

}
