using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eAttribute : short
{
    Wind = 0,
    Fire = 1,
    Thunder = 2
}

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

    

    //�� ����
    [SerializeField] private eAttribute attribute = eAttribute.Wind;

    void Start()
    {
        StartCoroutine(Fire());

        gauge = 0f;
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
    public void WindMode()
    {
        attribute = eAttribute.Wind;
    }

    public void FireMode()
    {
        attribute = eAttribute.Fire;
    }

    public void ThunderMode()
    {
        attribute = eAttribute.Thunder;
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
        GameObject attributePrefab = windPrefab;

        if (attribute == eAttribute.Wind) attributePrefab = windPrefab;
        if (attribute == eAttribute.Fire) attributePrefab = firePrefab;
        if (attribute == eAttribute.Thunder) attributePrefab = thunderPrefab;

        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            anim.SetTrigger("isAttack");
            Instantiate(attributePrefab, firePos.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
