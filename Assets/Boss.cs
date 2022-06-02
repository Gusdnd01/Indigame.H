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

    [SerializeField] private float bossHp;
    private float playerDamage;

    [SerializeField] private float currentTime;
    private float maxTime;

    private Animator anim;

    private float _randomSpawn;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Spawn());
    }

    private void RandonSpawn()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slash"))
        {
            playerDamage = UnityEngine.Random.Range(14, 21);
            bossHp -= playerDamage;
        }
    }

    IEnumerator Spawn()
    {
        while (true) 
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2f));
            int rand = UnityEngine.Random.Range(1, 4);
            if(rand == 1)
            {
                Instantiate(_attackPrefab, firstFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack");
            }
            else if(rand == 2)
            {
                Instantiate(_attackPrefab, secondFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack_1");
            }
            else if(rand == 3)
            {
                Instantiate(_attackPrefab, thirdFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack");
            }
        }

    }
}
