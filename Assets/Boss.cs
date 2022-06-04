using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private GameObject _warningPrefab;

    [SerializeField] private Transform firstFirePos;
    [SerializeField] private Transform secondFirePos;
    [SerializeField] private Transform thirdFirePos;

    private float _maxBossHp;
    private float currentHp;
    private float playerDamage;

    private float currentTime;
    private float maxTime;

    private Image _hpBar;

    private Animator anim;

    private float _randomSpawn;
    private bool isDeath = false;
    private RectTransform curtain;
    private RectTransform curtain_1;

    private void Start()
    {
        _maxBossHp = UnityEngine.Random.Range(100f, 200f);

        anim = GetComponent<Animator>();
        StartCoroutine(Spawn());

        curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();

        _hpBar = GameObject.Find("Canvas/BossHpBar/Amount").GetComponent<Image>();
        currentHp = _maxBossHp;

        print(currentHp);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slash"))
        {
            Destroy(collision.gameObject);
            playerDamage = UnityEngine.Random.Range(7, 13);
            currentHp -= playerDamage;
            _hpBar.fillAmount = currentHp / _maxBossHp;

            if (currentHp < 0)
            {
                isDeath = true;
                anim.SetTrigger("isDeath");
                StartCoroutine(Death(1f));
            }
            Debug.Log(playerDamage);
        }
    }

    void Update()
    {
        if(isDeath == true)
        {
            StopCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        while (true) 
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2f));
            int rand = UnityEngine.Random.Range(1, 4);
            if (rand == 1)
            {
                Instantiate(_attackPrefab, firstFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack");
            }
            else if (rand == 2)
            {
                Instantiate(_attackPrefab, secondFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack_1");
            }
            else if (rand == 3)
            {
                Instantiate(_attackPrefab, thirdFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack");
            }
        }
    }

    IEnumerator Death(float sec)
    {
        curtain.DOAnchorPosX(960, 0.5f);
        curtain_1.DOAnchorPosX(-960, 0.5f);
        yield return new WaitForSeconds(sec);
        isDeath = false;
        SceneManager.LoadScene(UnityEngine.Random.Range(2, 4));
    }
}
