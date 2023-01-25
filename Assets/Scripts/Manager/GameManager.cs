using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("게임시작")]
    [SerializeField] TextMeshProUGUI timer; // 남은 시간을 나타내는 타이머
    [SerializeField] Image readyImage; // 준비 시간을 나타내는 이미지
    [Header("스포너")]
    [SerializeField] GameObject balloonSpawner; // 풍선 생성기
    [SerializeField] GameObject feverSpawner; // 피버타임 생성기
    [SerializeField] GameObject rabbitSpawner; // 토끼 생성기
    [SerializeField] GameObject witheredPrefab; // 시든 꽃 프리팹

    public List<GameObject> bloom = new List<GameObject>(); // 스코어 산정을 위한 피어있는 꽃 리스트
    
    GameObject targetBlooming; // bloom 리스트에서 가장 먼저 추가된 피어있는 꽃(시든 꽃으로 변하기 위한 변수)
    GameObject targetWithered; // 꽃이 시들고 3초뒤에 사라지게 하기 위한 변수
    
    public bool isGameover; // 게임 종료를 나타내는 bool 값
    bool isWithered; // 꽃이 시듬을 나타내는 bool 값
    public bool isFeverTime; // 피버타임을 나타내는 bool 값
    Coroutine withered; // 꽃이 시들게 만드는 코루틴 변수

    private void OnEnable()
    {
        StartCoroutine(nameof(CO_ReadyOff));
        //StartCoroutine(CO_ReadyOff());
    }
    //void Start()
    //{
    //    StartCoroutine(nameof(CO_ReadyOff));
    //}
    private void Update()
    {
        if (isGameover == false)
        {
            // 슬라이더 값 3개 중에서 1개라도 30퍼센트 밑으로 내려가면 꽃이 시듦
            if ((UIManager.Inst.fertilizerSlider.value < 0.3f || UIManager.Inst.waterSlider.value < 0.3f || UIManager.Inst.sunSlider.value < 0.3f) && isWithered == false && bloom.Count != 0)
            {
                isWithered = true;
                targetBlooming = ListDequeue();
                withered = StartCoroutine(nameof(CO_WitheredFlower));
            }
        }
    }
    /// <summary>
    /// 게임 종료시 실행 되는 함수
    /// </summary>
    public void EndGame()
    {
        Debug.Log("게임 끝!");
        isGameover = true;
        balloonSpawner.SetActive(false);
        rabbitSpawner.SetActive(false);
        UIManager.Inst.GameoverOn();
    }

    /// <summary>
    /// 3초의 준비 시간을 이후에 게임이 시작되게 하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_ReadyOff()
    {
        Debug.Log("게임 시작!");
        yield return new WaitForSeconds(3.5f);
        Debug.Log("3초 끝");
        readyImage.gameObject.SetActive(false);
        balloonSpawner.SetActive(true);
        rabbitSpawner.SetActive(true);
        timer.gameObject.SetActive(true);

    }

    /// <summary>
    /// 꽃이 시들게 만드는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator CO_WitheredFlower()
    {
        
        //Debug.Log("3초 시작");
        targetBlooming.gameObject.SetActive(false); // 해당 꽃 오브젝트 제거
        targetWithered = DictionaryPool.Inst.Instantiate(witheredPrefab, targetBlooming.transform.position, Quaternion.identity, DictionaryPool.Inst.transform); // 그 위치에 시든 꽃 오브젝트 생성
        yield return new WaitForSeconds(3f);
        //Debug.Log("3초 끝 시들어라");
        DictionaryPool.Inst.Release(targetWithered); // 시든 꽃 오브젝트 제거
        isWithered = false;
    }

    /// <summary>
    /// 피버 타임 적용 함수
    /// </summary>
    public void FeverSpawnerOn()
    {
        isFeverTime = true;
        balloonSpawner.SetActive(false);
        feverSpawner.SetActive(true);
        UIManager.Inst.feverText.gameObject.SetActive(true);
        StartCoroutine(nameof(CO_FeverSpawnerOff));
    }

    /// <summary>
    /// 피버 타임 해제 코루틴
    /// </summary>
    /// <returns></returns>
    public IEnumerator CO_FeverSpawnerOff()
    {
        yield return new WaitForSeconds(7f);
        UIManager.Inst.feverText.gameObject.SetActive(false);
        feverSpawner.SetActive(false);
        isFeverTime = false;
        balloonSpawner.SetActive(true);
    }

    /// <summary>
    /// 스코어 산정을 위한 피어있는 꽃 리스트에 추가하는 함수
    /// </summary>
    /// <param name="obj"></param>
    public void ListEnqueue(GameObject obj)
    {
        bloom.Add(obj);
    }

    /// <summary>
    /// 피어있는 꽃 리스트에서 제일 먼저 들어간 꽃을 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public GameObject ListDequeue()
    {
        GameObject selectObj = bloom[0];
        bloom.RemoveAt(0);
        return selectObj;
    }

}
