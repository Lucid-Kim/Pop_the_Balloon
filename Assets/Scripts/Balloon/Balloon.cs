using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject[] obj; // 풍선마다의 출력하는 이펙트나 추가되는 오브젝트
    /// <summary>
    /// 2구역에 생성하기위한 랜덤 X좌표
    /// </summary>
    protected float ranPosX;
    /// <summary>
    /// 2구역에 생성하기위한 랜덤 Y좌표
    /// </summary>
    protected float ranPosY;
    /// <summary>
    /// 2구역 풍선의 점수를 나타내는 텍스트를 스크린 포지션으로 가져오기 위한 메인 캠
    /// </summary>
    protected Camera cam;
    
    float speed = 5;
    int movedir = 0;
    public virtual void Interact()
    {
        ranPosX = Random.Range(1f, 8f);
        ranPosY = Random.Range(-4.5f, 2f);
        cam = Camera.main;
        DictionaryPool.Inst.Release(gameObject);
        // 풍선 터지는 오브젝트 생성
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);
    }
    protected virtual void Update()
    {
        transform.Translate(0, 1f * Time.deltaTime * speed, 0); // 일정하게 올라가게 설정
    }

    protected virtual void Floating()
    {
        StartCoroutine(nameof(CO_Floating));
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
