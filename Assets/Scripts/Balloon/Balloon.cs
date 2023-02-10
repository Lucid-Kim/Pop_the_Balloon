using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon : MonoBehaviour, Object_Interactable
{
    
    [SerializeField] protected GameObject[] obj; // 풍선마다의 출력하는 이펙트나 추가되는 오브젝트
    [SerializeField] GameObject balloonEffect;
    [SerializeField] GameObject effect;
    [SerializeField] GameObject scorePrefab;
    [SerializeField] float speed = 5; // 풍선이 뜨는 속도
    [SerializeField] int collaborationIdx; // 협동모드 구역을 나타내는 인덱스

    [SerializeField] bool isFlowered;     // 풍선이 꽃 풍선인지 확인하는 bool 값
    [SerializeField] Vector3 objPosition; // 오브젝트의 위치 변경이 필요할 때 사용하는 변수 obj[1] 의 위치
    [SerializeField] Vector3 objRotation; // 오브젝트의 회전 변경이 필요할 때 사용하는 변수 obj[1] 의 회전값

    [Header("점수 확인용")]
    [SerializeField] bool isScored; // 점수 표시되어야 하는지 확인하는 bool 값
    [SerializeField] int addedScore; // 추가되는 점수
    TextMeshProUGUI scoreText; // 

    
    protected Camera cam;    // 2구역 풍선의 점수를 나타내는 텍스트를 스크린 포지션으로 가져오기 위한 메인 캠
    int movedir = 0;

    private void OnEnable()
    {
        Floating();
    }
    public virtual void Interact()
    {
        float ranPosX = Random.Range(1f, 8f);  // 2구역에 생성하기위한 랜덤 X좌표
        float ranPosY = Random.Range(-4.5f, 2f); // 2구역에 생성하기위한 랜덤 Y좌표
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // 풍선 터지는 오브젝트 생성
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);

        // 협동모드이며 1구역 풍선이라면
        if (GameDatas.Inst.mode == Mode.COLLABORATION && collaborationIdx == 1 && GameManager.Inst.Region2Spawned() == true)
        {
            if (isFlowered == true)
            {
                int balloonIdx = Random.Range(1, 6);
                // 2구역에 꽃풍선 생성
                DictionaryPool.Inst.Instantiate(obj[balloonIdx], new Vector2(ranPosX, ranPosY), Quaternion.identity, DictionaryPool.Inst.transform);
            }
            else
            {
                // 2구역에 해당하는 풍선 생성
                DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, ranPosY, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            }
            GameManager.Inst.Region2AddCount(1);
        }
        // 협동모드이며 2구역 & 개인모드 풍선이라면
        else
        {
            if (isFlowered == true)
            {
                ranPosX = Random.Range(-8f, 8f);
                // 꽃 생성 (현재는 랜덤생성인데 기획에서 내용 바뀌면 위치 바꿔줘야함) ///////////
                DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            }
            else
            {
                // 1번 오브젝트 위치및 회전값 설정
                GameObject obj1 = DictionaryPool.Inst.Instantiate(obj[1], new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
                obj1.transform.position = objPosition;
                obj1.transform.rotation = Quaternion.Euler(objRotation);
            }
            GameManager.Inst.Region2AddCount(-1);
        }

        if (isScored == true) // 점수 텍스트가 있어야 한다면
        {
            // 점수 올라가는 텍스트 생성
            GameObject temp = DictionaryPool.Inst.Instantiate(obj[2], cam.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)), Quaternion.identity, GameObject.Find("UI").transform);
            scoreText = temp.GetComponent<TextMeshProUGUI>();
            if (addedScore >= 0)
            {
                scoreText.text = "+" + addedScore;
            }
            else scoreText.text = addedScore.ToString();
            // 게임매니저에서 관리하는 점수 올리기
            GameManager.Inst.score += addedScore;
            // UI 텍스트 점수 변경
            UIManager.Inst.UpdateScore();
        }
    }
    protected virtual void Update()
    {
        if (collaborationIdx == 1 || GameDatas.Inst.mode == Mode.PERSONAL)
        {
            transform.Translate(0, 1f * Time.deltaTime * speed, 0); // 일정하게 올라가게 설정
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
    /// 풍선의 움직임을 좌우로 일정하게 움직이게 설정
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator CO_Floating()
    {
        while (transform.position.y < 6)
        {
            if (movedir == 0) // 오른쪽 방향
            {
                transform.Translate(0.3f * Time.deltaTime * speed, 0, 0);
                movedir = 1;
            }
            else // 왼쪽 방향
            {
                transform.Translate(-0.3f * Time.deltaTime * speed, 0, 0);
                movedir = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
        DictionaryPool.Inst.Release(this.gameObject);
    }

}
