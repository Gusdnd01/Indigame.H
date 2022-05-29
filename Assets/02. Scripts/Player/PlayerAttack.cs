using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Header("������ ������ ��ġ")]
    [SerializeField] private Transform firePos;

    [Header("Slash������ ����")]
    [SerializeField] private GameObject windPrefab;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject thunderPrefab;
    [SerializeField] private AudioClip slashSound;
    [SerializeField] private Animator anim;
    
    [Header("��Ŭ�� ������ �� �� �ִ� ������ ����")]
    [SerializeField] private float gauge = 0f;
    
    [Header("�ڽ�ĳ��Ʈ�� �Ǻ��ϴ� ���̾�")]
    [SerializeField] private LayerMask layerMask;

    [Header("������ ��ġ����")]
    [SerializeField] private float damage;
    [SerializeField] private float hp;

    private UIManager _uiManager;

    void Start()
    {
        StartCoroutine(Fire());

        gauge = 0f;

        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    void Update()
    {
        Mouse2();
        GaugeFill();
    }

    void Mouse2()
    {
        if (Input.GetMouseButtonDown(1) && gauge == 1f)
        {
            Hit();
        }
    }

    private void GaugeFill()
    {
        
    }

    private void Hit()
    {
        gauge = 0f;

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
            anim.SetTrigger("isAttack");
            Instantiate(windPrefab, firePos.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
