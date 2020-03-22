using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

    static PoolManager _instance;

    public static PoolManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>();
            }
            return _instance;
        }
    }



    public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();
        Debug.Log("Pool" + prefab.name);
        if(!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());
            for(int i = 0; i <poolSize; i++)
            {
                GameObject newObj = Instantiate(prefab) as GameObject;
                newObj.SetActive(false);
                poolDictionary[poolKey].Enqueue(newObj);
            }
        }
    }

    public GameObject ReuseObject (GameObject prefab, Vector2 position, Quaternion rotation)
    {
        GameObject obj;
        int poolKey = prefab.GetInstanceID();
        if (poolDictionary.ContainsKey(poolKey))
        {
            obj = poolDictionary[poolKey].Dequeue();
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            poolDictionary[poolKey].Enqueue(obj);
            return obj;
        }
        return null;
    }
}
