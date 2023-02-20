using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject balloonEffect; // 풍선이 터질 때 나오는 이펙트
    [SerializeField] protected GameObject effect; // 풍선의 특징에 따른 이펙트
    [SerializeField] protected GameObject scorePrefab; // 점수를 나타내는프리팹
    [SerializeField] float speed = 5; // 풍선이 뜨는 속도
    [SerializeField] protected int collaborationIdx; // 협동모드 구역을 나타내는 인덱스

    [SerializeField] Vector3 objPosition; // 오브젝트의 위치 변경이 필요할 때 사용하는 변수 effect 의 위치
    [SerializeField] Vector3 objRotation; // 오브젝트의 회전 변경이 필요할 때 사용하는 변수 effect 의 회전값

    [Header("점수 확인용")]
    [SerializeField] protected bool isScored; // 점수 표시되어야 하는지 확인하는 bool 값
    [SerializeField] protected int addedScore; // 추가되는 점수
    protected TextMeshProUGUI scoreText; // 점수를 나타내는 텍스트
    protected float maxPosX = 9f; // 생성이 될 수 있는 최대 x좌표
    protected float centerPosX = 1f; // 중간의 선을 나타내는 x좌표
    
    protected Camera cam;    // 2구역 풍선의 점수를 나타내는 텍스트를 스크린 포지션으로 가져오기 위한 메인 캠
    int movedir = 0;

    private void OnEnable()
    {
        Floating();
    }

    private void Start()
    {
        if (GameDatas.Inst.mode == Mode.COLLABORATION) // 협동 모드 일 경우
        {
            if (collaborationIdx == 1)
            {
                speed = 2;
            }
        }
        else // 개인 모드 일 경우
        {
            if (addedScore < 0) // 폭탄 풍선일 경우
            {
                switch (GameDatas.Inst.difficulty)
                {
                    case DIFFICULTY.NORMAL:
                        speed = 4;
                        break;
                    case DIFFICULTY.HARD:
                        speed = 3;
                        break;
                    case DIFFICULTY.MASTER:
                        speed = 2;
                        break;
                }
            }
            else // 일반 풍선일 경우
            {
                switch (GameDatas.Inst.difficulty)
                {
                    case DIFFICULTY.EASY:
                        speed = 2;
                        break;
                    case DIFFICULTY.NORMAL:
                        speed = 3;
                        break;
                    case DIFFICULTY.HARD:
                        speed = 4;
                        break;
                    case DIFFICULTY.MASTER:
                        speed = 5;
                        break;
                }
            }
        }
    }
    public virtual void Interact()
    {
        float ranPosX = Random.Range(centerPosX, maxPosX);  // 2구역에 생성하기위한 랜덤 X좌표
        float ranPosY = Random.Range(-3f, 2f); // 2구역에 생성하기위한 랜덤 Y좌표
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // 풍선 터지는 오브젝트 생성
        DictionaryPool.Inst.Instantiate(balloonEffect, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);
        SoundManager.Inst.PlaySFX("BalloonPopSFX");

        // 협동모드이며 1구역 풍선이라면
        if (GameDatas.Inst.mode == Mode.COLLABORATION && collaborationIdx == 1 && GameManager.Inst.Region2Spawned() == true)
        {
            // 2구역에 해당하는 풍선 생성
            DictionaryPool.Inst.Instantiate(effect, new Vector3(ranPosX, ranPosY, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            GameManager.Inst.Region2AddCount(1);
        }
        // 협동모드이며 2구역 & 개인모드 풍선이라면
        else if (GameDatas.Inst.mode == Mode.PERSONAL || collaborationIdx == 2)
        {
            // 1번 오브젝트 위치및 회전값 설정
            GameObject obj1 = DictionaryPool.Inst.Instantiate(effect, new Vector3(ranPosX, -4, 0), Quaternion.identity, DictionaryPool.Inst.transform);
            obj1.transform.position = objPosition;
            obj1.transform.rotation = Quaternion.Euler(objRotation);
            
            GameManager.Inst.Region2AddCount(-1);
        }

        if (isScored == true) // 점수 텍스트가 있어야 한다면
        {
            ShowScore();
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

    /// <summary>
    /// 점수를 이미지로 보여주는 함수
    /// </summary>
    protected virtual void ShowScore()
    {
        // 점수 올라가는 이미지 생성
        DictionaryPool.Inst.Instantiate(scorePrefab, transform.position, Quaternion.identity,DictionaryPool.Inst.transform);
        
        // 폭탄 풍선일 때
        if (addedScore < 0)
        {
            SoundManager.Inst.PlaySFX("BombSFX");
        }
        
        // 게임매니저에서 관리하는 점수 올리기
        GameManager.Inst.score += addedScore;
        // UI 텍스트 점수 변경
        UIManager.Inst.UpdateScore();
    }
}
