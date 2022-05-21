using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Header("공격이 나가는 위치")]
    [SerializeField] private Transform firePos;

    [Header("Slash프리팹 관련")]
    [SerializeField] private GameObject slash;
    [SerializeField] private AudioClip slashSound;
    [SerializeField] private Animator anim;
    
    [Header("우클릭 공격을 할 수 있는 게이지 관련")]
    [SerializeField] private float gauge = 0f;
    [SerializeField] private Image image;
    
    [Header("박스캐스트가 판별하는 레이어")]
    [SerializeField] private LayerMask layerMask;

    [Header("데미지 수치관련")]
    [SerializeField] private float damage;
    [SerializeField] private float hp;

    void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        Mouse2();
        GaugeFill();
    }

    void Mouse2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isAttack");
        }
        if (Input.GetMouseButtonDown(1) && gauge == 1f)
        {
            Hit();

            gauge = 0f;
        }
    }

    private void GaugeFill()
    {
        gauge += Time.deltaTime;

        Mathf.Clamp(gauge, 0f, 1f);

        image.fillAmount = gauge;
    }

    private void Hit()
    {
        RaycastHit2D hit = Physics2D.BoxCast(firePos.position, new Vector2(3, 5), 0, new Vector2(1, 0), 0.1f, layerMask);

        if (hit)
        {

        }
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            Instantiate(slash, firePos.position, Quaternion.identity);
            
            PoolManager.GetObject();
            yield return new WaitForSeconds(1f);
        }

        
    }
}
