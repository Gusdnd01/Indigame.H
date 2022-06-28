using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _attackPrefab;
    void Start()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(_attackPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
