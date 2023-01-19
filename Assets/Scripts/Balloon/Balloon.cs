using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject[] obj; // ǳ�������� ����ϴ� ����Ʈ�� �߰��Ǵ� ������Ʈ
    protected int ranNum;
    float ranMoveX;
    float speed = 5;
    int movedir = 0;
    public virtual void Interact()
    {
        
    }
    protected virtual void Update()
    {
        transform.Translate(0, 1f * Time.deltaTime * speed, 0); // �����ϰ� �ö󰡰� ����
    }

    protected virtual void Floating()
    {
        StartCoroutine(nameof(CO_Floating));
    }
    /// <summary>
    /// ǳ���� �������� �¿�� �����ϰ� �����̰� ����
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator CO_Floating()
    {
        while (transform.position.y < 6)
        {
            if (movedir == 0) // ������ ����
            {
                transform.Translate(0.3f * Time.deltaTime * speed, 0, 0);
                movedir = 1;
            }
            else // ���� ����
            {
                transform.Translate(-0.3f * Time.deltaTime * speed, 0, 0);
                movedir = 0;
            }
            yield return new WaitForSeconds(0.1f);   
        }
        DictionaryPool.Inst.Destroy(this.gameObject);
    }

}
