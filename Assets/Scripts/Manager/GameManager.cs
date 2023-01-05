using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] Image readyImage;
    [SerializeField] GameObject balloonSpawner;
    GameObject targetBlooming;
    [SerializeField] Sprite witheredImage;
    [SerializeField] Sprite bloomingImage;
    public Queue<GameObject> bloom = new Queue<GameObject>();
    public Queue<GameObject> witheredFlowerQueue = new Queue<GameObject>();
    public bool isGameover;
    bool isWithered;
    Coroutine withered;
    float time = 0;
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
            if ((UIManager.Inst.fertilizerSlider.value <= 0.6f || UIManager.Inst.waterSlider.value <= 0.6f || UIManager.Inst.sunSlider.value <= 0.6f) && isWithered == false)
            {
                isWithered = true;
                targetBlooming = bloom.Peek();
                withered = StartCoroutine(CO_WitheredFlower());
            }
            else if (UIManager.Inst.fertilizerSlider.value > 0.6f & UIManager.Inst.waterSlider.value > 0.6f & UIManager.Inst.sunSlider.value > 0.6f && isWithered == true)
            {
                if (withered != null)
                {
                    Debug.Log("복구해");
                    StopCoroutine(withered);
                    targetBlooming.GetComponent<SpriteRenderer>().sprite = bloomingImage;
                    witheredFlowerQueue.Dequeue();
                    withered = null;
                    isWithered = false;
                }
                //여기서
            }
        }
    }
    public void EndGame()
    {
        Debug.Log("게임 끝!");
        isGameover = true;
        balloonSpawner.SetActive(false);
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
        time = 0f;
        Debug.Log("5초 시작");
        yield return new WaitForSeconds(5f);
        Debug.Log("5초 끝 시들어라");
        targetBlooming.GetComponent<SpriteRenderer>().sprite = witheredImage;
        witheredFlowerQueue.Enqueue(targetBlooming);
        while (time < 10f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log(witheredFlowerQueue.Count);
        isWithered = false;
        bloom.Dequeue();
    }

    //IEnumerator CO_RestoredFlower()
    //{

    //}



}
