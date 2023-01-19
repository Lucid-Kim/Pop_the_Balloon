using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject[] obj; // 풍선마다의 출력하는 이펙트나 추가되는 오브젝트
    protected int ranNum;
    float ranMoveX;
    float speed = 5;
    int movedir = 0;
    public virtual void Interact()
    {
        
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
        DictionaryPool.Inst.Destroy(this.gameObject);
    }

}
