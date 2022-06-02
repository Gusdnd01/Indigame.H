using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [Header("공격이 나가는 위치")]
    [SerializeField] private Transform firePos;

    [Header("Slash프리팹 관련")]
    [SerializeField] private GameObject windPrefab;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject thunderPrefab;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private AudioClip slashSound;
    [SerializeField] private Animator anim;

    public float gauge;
    
    [Header("박스캐스트가 판별하는 레이어")]
    [SerializeField] private LayerMask layerMask;

    [Header("데미지 수치관련")]
    [SerializeField] private float damage;
    [SerializeField] private float maxHp;
    private float currentHp;

    private Slider _slider;
    private UIManager _uiManager;

    private RectTransform _curtain;
    private RectTransform _curtain_1;

    void Start()
    {
        StartCoroutine(Fire());
        
        _slider = GameObject.Find("Canvas/Slider").GetComponent<Slider>();

        _curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        _curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();

        gauge = 0f;

        _uiManager = GameObject.FindObjectOfType<UIManager>();
        currentHp = maxHp;
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
            currentHp -= damage;
            if(currentHp < 0f)
            {
                StartCoroutine(Death(2.5f));
            }
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
            //범위 좀 작게두고, 데미지는 총알보다는 살짝 높게할거임
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

    IEnumerator Death(float sec)
    {
        _curtain.DOAnchorPosX(960, 0.5f);
        _curtain_1.DOAnchorPosX(-960, 0.5f);

        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene("Ending");
    }
}
