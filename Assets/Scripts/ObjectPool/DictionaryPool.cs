using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryPool : Singleton<DictionaryPool>
{
    private Dictionary<string, List<GameObject>> instList = new Dictionary<string, List<GameObject>>();
    //Call instantiate
    public GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        List<GameObject> list = null;
        GameObject instance = null;

        bool listCheck = instList.TryGetValue(prefab.name, out list);
        if (listCheck == false)
        {
            list = new List<GameObject>();
            instList.Add(prefab.name, list);
        }
        if (list.Count == 0)
        {
            instance = GameObject.Instantiate(prefab, position, rotation, parent);
        }
        else if (list.Count > 0)
        {
            instance = list[0];
            instance.transform.position = position + new Vector3(0, 0.3f, 0);
            instance.transform.rotation = rotation;
            list.RemoveAt(0);
        }
        if (instance != null)
        {
            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            return null;
        }
    }
    //Call bringObject & Pooling
    public void Destroy(GameObject Prefab)
    {
        List<GameObject> list = null;
        string prefabId = Prefab.name.Replace("(Clone)", "");
        bool listCached = instList.TryGetValue(prefabId, out list);
        if (listCached == false)
        {
            Debug.LogError("Not Found " + Prefab.name);
            return;
        }

        Prefab.SetActive(false);
        list.Add(Prefab);

    }

    
}
