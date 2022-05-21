using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    [SerializeField]
    private GameObject slashPrefabs;

    Queue<SlashObject> poolQueue = new Queue<SlashObject>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("PoolManager instance is running!");
        }
        instance = this;

        Initialize(10);
    }

    void Initialize(int initializeCount)
    {
        for(int i = 0; i < initializeCount; i++)
        {
            poolQueue.Enqueue(CreateNewObject());
        }
    }

    private SlashObject CreateNewObject()
    {
        var newObject = Instantiate(slashPrefabs).GetComponent<SlashObject>();
        newObject.gameObject.SetActive(false);
        newObject.transform.SetParent(transform);
        return newObject;
    }

    public static SlashObject GetObject()
    {
        if (instance.poolQueue.Count > 0)
        {
            var obj = instance.poolQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else 
        {
            var newObj = instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(SlashObject slash)
    {
        slash.gameObject.SetActive(false);
        slash.transform.SetParent(instance.transform);
        instance.poolQueue.Enqueue(slash);
    }
}
