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
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private AudioClip slashSound;
    [SerializeField] private Animator anim;

    public float gauge;
    
    [Header("�ڽ�ĳ��Ʈ�� �Ǻ��ϴ� ���̾�")]
    [SerializeField] private LayerMask layerMask;

    [Header("������ ��ġ����")]
    [SerializeField] private float damage;
    [SerializeField] private float hp;

    private Slider _slider;
    private UIManager _uiManager;

    void Start()
    {
        StartCoroutine(Fire());
        
        _slider = GameObject.Find("Canvas/Slider").GetComponent<Slider>();

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            hp -= damage;
        }
    }

    private void GaugeFill()
    {
        gauge += Time.deltaTime;
    }

    private void Hit()
    {
        gauge -= 1f;

        RaycastHit2D hit = Physics2D.BoxCast(firePos.position, new Vector2(3, 5), 0, new Vector2(1, 0), 0.1f, layerMask);
        Debug.DrawRay(hit.point, Vector3.right, Color.white, 0.2f);

        if (hit)
        {
            //���� �� �۰Եΰ�, �������� �Ѿ˺��ٴ� ��¦ �����Ұ���
        }
    }

    IEnumerator Fire()
    {
        GameObject attributePrefab;

        if(StartScene.instance._wind == true && StartScene.instance._fire == false 
            && StartScene.instance._thunder == false && StartScene.instance._water == false)
        {
            attributePrefab = windPrefab;
        }
        else if (StartScene.instance._wind == false && StartScene.instance._fire == true 
            && StartScene.instance._thunder == false && StartScene.instance._water == false)
        {
            attributePrefab = firePrefab;
        }
        else if(StartScene.instance._wind == false && StartScene.instance._fire == false
            && StartScene.instance._thunder == true && StartScene.instance._water == false)
        {
            attributePrefab = thunderPrefab;
        }
        else
        {
            attributePrefab = waterPrefab;
        }

        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            anim.SetTrigger("isAttack");
            Instantiate(attributePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
