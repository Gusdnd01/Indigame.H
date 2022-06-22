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

    private Transform firstFirePos;
    private Transform secondFirePos;
    private Transform thirdFirePos;

    private float _maxBossHp;
    private float currentHp;
    private float playerDamage;

    bool isDissolve = false;
    float fade = 1f;
    Material material;

    private Image _hpBar;

    private Animator anim;

    public float sec;
    public float sec_1;

    private float _randomSpawn;
    private bool isDeath = false;
    private RectTransform curtain;
    private RectTransform curtain_1;

    int score;
    
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }
    private void Awake()
    {
        firstFirePos = GameObject.Find("FirePosManager/firePos").GetComponent<Transform>();
        secondFirePos = GameObject.Find("FirePosManager/firePos2").GetComponent<Transform>();
        thirdFirePos = GameObject.Find("FirePosManager/firePos3").GetComponent<Transform>();
    }
    private void Start()
    {
        _maxBossHp = UnityEngine.Random.Range(200, 400);

        anim = GetComponent<Animator>();
        StartCoroutine(Spawn());

        curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();

        _hpBar = GameObject.Find("Canvas/BossHpBar/Amount").GetComponent<Image>();
        material = GetComponent<SpriteRenderer>().material;
        currentHp = _maxBossHp;
    }

    private void Update()
    {
        if (isDissolve)
        {
            fade -= Time.deltaTime;

            if(fade <= 0f)
            {
                fade = 0f;
                isDissolve = false;
            }

            material.SetFloat("_Dissolve", fade);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slash"))
        {
            Destroy(collision.gameObject);
            currentHp -= playerDamage;
            _hpBar.fillAmount = currentHp / _maxBossHp;

            if (StartScene.instance._wind == true && StartScene.instance._fire == false
            && StartScene.instance._thunder == false && StartScene.instance._water == false)
            {
                playerDamage = UnityEngine.Random.Range(1, 20);
            }
            else if (StartScene.instance._wind == false && StartScene.instance._fire == true
                && StartScene.instance._thunder == false && StartScene.instance._water == false)
            {
                playerDamage = 20;
            }
            else if (StartScene.instance._wind == false && StartScene.instance._fire == false
                && StartScene.instance._thunder == true && StartScene.instance._water == false)
            {
                playerDamage = UnityEngine.Random.Range(10, 15);
            }
            else
            {
                playerDamage = UnityEngine.Random.Range(5, 10);
            }
            if (currentHp <= 0 && isDeath == false)
            {
                isDeath = true;
                isDissolve = true;
                StartCoroutine(Death(1f));
                StopCoroutine(Spawn());

                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
                print(PlayerPrefs.GetInt("Score"));
            }
        }
    }

    IEnumerator Spawn()
    {
        while (isDeath == false) 
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(sec, sec_1));
            int rand = UnityEngine.Random.Range(1, 4);
            if (rand == 1)
            {
                Instantiate(_attackPrefab, firstFirePos.position, Quaternion.identity);
                anim.SetTrigger("isAttack");
            }
            else if (rand == 2)
            {
                Instantiate(_attackPrefab, secondFirePos.position, Quaternion.identity);
                Instantiate(_warningPrefab, secondFirePos.position, Quaternion.identity);
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
        yield return new WaitForSeconds(1f);
        curtain.DOAnchorPosX(960, 0.5f);
        curtain_1.DOAnchorPosX(-960, 0.5f);
        yield return new WaitForSeconds(sec);
        isDeath = false;
        if(score < 5)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
