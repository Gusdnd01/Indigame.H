using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolingObject : MonoBehaviour
{

    public static PoolingObject instance;

    [SerializeField] // 인스펙터에 해당 변수를 보여줌
    List<GameObject> m_poolObject = new List<GameObject>(); // 오브젝트 풀에 보관되는 오브젝트

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    public GameObject GetObjFromPool(int id, Transform t) // Pool => Scene
    {
        GameObject obj = m_poolObject[id];

        obj.transform.parent = t;
        obj.transform.position = t.position;
        obj.SetActive(true);
        return obj;
    }
    public void BackObjToPool(int id) // Scene => Pool (id로 호출)
    {
        GameObject obj = m_poolObject[id];
        obj.transform.parent = this.transform;
        obj.SetActive(false);
    }
    public void BackObjToPool(GameObject go) // Scene => Pool (GameObject로 호출)
    {
        int index = m_poolObject.FindIndex(x => x == go);
        GameObject obj = m_poolObject[index];
        obj.transform.parent = this.transform;
        obj.SetActive(false);
    }
}

