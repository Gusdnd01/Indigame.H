using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private GameObject _warningPrefab;

    [SerializeField] private Transform firstFirePos;
    [SerializeField] private Transform secondFirePos;
    [SerializeField] private Transform thirdFirePos;

    [SerializeField] private float currentTime;
    private float maxTime;

    private float _randomSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void RandonSpawn()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true) 
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(3, 5));
            int rand = UnityEngine.Random.Range(1, 3);
            if(rand == 1)
            {
                Instantiate(_attackPrefab, firstFirePos.position, Quaternion.identity);
            }
            else if(rand == 2)
            {
                Instantiate(_attackPrefab, secondFirePos.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_attackPrefab, thirdFirePos.position, Quaternion.identity);
            }
        }

    }
}
