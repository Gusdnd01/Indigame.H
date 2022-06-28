using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LastBoss : MonoBehaviour
{
    public float maxHp = 1000;
    public float currentHp;
    float damage;

    SlashSin slash;
    BossPattern pattern;
    Material material;

    Animator anim; 

    Image slider;

    bool isDissolve = false;
    bool isDead = false;
    float fade = 1;
    private RectTransform _curtain;
    private RectTransform _curtain_1;
    private LastBossPlayer _player;

    private void Start()
    {
        currentHp = maxHp;

        slider = GameObject.Find("Canvas/BossHpBar/Amount").GetComponent<Image>();
        _curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        _curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();
        slash = GetComponent<SlashSin>();
        pattern = GetComponent<BossPattern>();
        material = GetComponent<Material>();
        anim = GetComponent<Animator>();
        _player = FindObjectOfType<LastBossPlayer>();
    }

    private void Update()
    {

        if (isDead)
        {
            slash.shakeSpeed = 0;

            
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentHp = 0;
        }
    }

    public void SceneMove()
    {
        StartCoroutine(SceneMove_1());
    }

    IEnumerator SceneMove_1()
    {
        _curtain.DOAnchorPosX(960, 0.5f);
        _curtain_1.DOAnchorPosX(-960, 0.5f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slash"))
        {
            if (StartScene.instance._wind == true && StartScene.instance._fire == false
            && StartScene.instance._thunder == false && StartScene.instance._water == false)
            {
                damage = UnityEngine.Random.Range(1, 20);
            }
            else if (StartScene.instance._wind == false && StartScene.instance._fire == true
                && StartScene.instance._thunder == false && StartScene.instance._water == false)
            {
                damage = 20;
            }
            else if (StartScene.instance._wind == false && StartScene.instance._fire == false
                && StartScene.instance._thunder == true && StartScene.instance._water == false)
            {
                damage = UnityEngine.Random.Range(10, 15);
            }
            else
            {
                damage = UnityEngine.Random.Range(5, 10);
            }

            Destroy(collision.gameObject);
            anim.SetTrigger("isAya");
            currentHp -= damage;

            slider.fillAmount = currentHp / maxHp;

            print(currentHp);

            if(currentHp <= 0)
            {
                pattern.sec = 99;
                _player.currentHp = 100;
                isDead = true;
                isDissolve = true;
                anim.SetBool("isDead", true);

                CameraManager.instance.BossDeathCamActive();
            }
        }
    }
}
