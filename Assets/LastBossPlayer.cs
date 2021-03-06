using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LastBossPlayer : MonoBehaviour
{
    [SerializeField] private GameObject windPrefab;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject thunderPrefab;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private AudioClip slashSound;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform firePos;
    private RectTransform _hpBar;
    private RectTransform _skillBar;
    private Image _hpBarAmount;
    private Image _skillBarAmount;
    private RectTransform _curtain;
    private RectTransform _curtain_1;

    public float gauge;

    [Header("박스캐스트가 판별하는 레이어")]
    [SerializeField] private LayerMask layerMask;

    [Header("데미지 수치관련")]
    [SerializeField] private float damage;
    [SerializeField] private float maxHp;
    public float currentHp;
    float sec;

    [Header("스킬 게이지 관련")]
    [SerializeField] private float maxGauge_skill;
    [SerializeField] private float currentGauge_skill;
    AudioSource audioSource;
    Image blink;


    void Start()
    {
        currentGauge_skill = maxGauge_skill;
        _hpBar = GameObject.Find("Canvas/HpBar").GetComponent<RectTransform>();
        _skillBar = GameObject.Find("Canvas/SkillBar").GetComponent<RectTransform>();
        _hpBarAmount = _hpBar.Find("Amount").GetComponent<Image>();
        _skillBarAmount = _skillBar.Find("Amount").GetComponent<Image>();
        _curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        _curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();
        blink = GameObject.Find("Canvas/Blink").GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Fire());
        StartCoroutine(UseSkill());

        currentHp = maxHp;
    }
    public void AudioPlay()
    {
        audioSource.Play();
    }


    void Update()
    {
        if (currentGauge_skill < 100)
        {
            currentGauge_skill += 1f;
            _skillBarAmount.fillAmount = currentGauge_skill / maxGauge_skill;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RectTransform rect = _hpBar.GetComponent<RectTransform>();

        if (collision.gameObject.CompareTag("Bullet"))
        {
            rect.DOShakeAnchorPos(1f, 10, 10);
            Destroy(collision.gameObject);
            damage = UnityEngine.Random.Range(3, 5);
            Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            PlayerDamage(damage);

            _hpBarAmount.fillAmount = currentHp / maxHp;
            
        }
    }

    public float PlayerDamage(float damage)
    {
        currentHp -= damage;

        _hpBarAmount.fillAmount = currentHp / maxHp;

        if (currentHp <= 0f)
        {
            StartCoroutine(Death(2.5f));
        }

        print(currentHp);
        return currentHp;
    }

    IEnumerator Fire()
    {

        GameObject attributePrefab;

        if (StartScene.instance._wind == true && StartScene.instance._fire == false
            && StartScene.instance._thunder == false && StartScene.instance._water == false)
        {
            attributePrefab = windPrefab;
            sec = 1f;

        }
        else if (StartScene.instance._wind == false && StartScene.instance._fire == true
            && StartScene.instance._thunder == false && StartScene.instance._water == false)
        {
            attributePrefab = firePrefab;
            sec = 1.3f;

        }
        else if (StartScene.instance._wind == false && StartScene.instance._fire == false
            && StartScene.instance._thunder == true && StartScene.instance._water == false)
        {
            attributePrefab = thunderPrefab;
            sec = 0.8f;
        }
        else
        {
            attributePrefab = waterPrefab;
            sec = 0.4f;
        }

        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            anim.SetTrigger("isAttack");
            Instantiate(attributePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(sec);
        }
    }
    private void Hit()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePos.position, Vector2.right, 3, layerMask);
        Debug.DrawRay(hit.point, Vector3.right, Color.blue, 1f);
        Sequence seq = DOTween.Sequence();
        if (hit)
        {
            print("asdadaf");
            Destroy(hit.transform.gameObject);
            seq.Append(blink.DOFade(0.8f, 0.1f));
            seq.Append(blink.DOFade(0f, 0.1f));
        }
    }

    IEnumerator UseSkill()
    {
        while (true)
        {
            if (currentGauge_skill >= 100)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
                Hit();
                anim.SetTrigger("isSkill");
                currentGauge_skill -= 100f;
            }
            yield return new WaitForSeconds(0.1f);
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
