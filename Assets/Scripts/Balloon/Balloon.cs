using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour, Object_Interactable
{
    [SerializeField] protected GameObject[] obj; // ǳ�������� ����ϴ� ����Ʈ�� �߰��Ǵ� ������Ʈ
    /// <summary>
    /// 2������ �����ϱ����� ���� X��ǥ
    /// </summary>
    protected float ranPosX;
    /// <summary>
    /// 2������ �����ϱ����� ���� Y��ǥ
    /// </summary>
    protected float ranPosY;
    /// <summary>
    /// 2���� ǳ���� ������ ��Ÿ���� �ؽ�Ʈ�� ��ũ�� ���������� �������� ���� ���� ķ
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
        // ǳ�� ������ ������Ʈ ����
        DictionaryPool.Inst.Instantiate(obj[0], gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity, DictionaryPool.Inst.transform);
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
        DictionaryPool.Inst.Release(this.gameObject);
    }

}
