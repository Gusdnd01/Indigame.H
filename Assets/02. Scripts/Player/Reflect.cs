using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Reflect : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;
    [SerializeField] private int maxReflectCount = 3;
    int reflectCount;
    private RectTransform _hpBar;

    float damage;

    LastBossPlayer player;


    private void Awake()
    {
        player = FindObjectOfType<LastBossPlayer>();
        _hpBar = GameObject.Find("Canvas/HpBar").GetComponent<RectTransform>();
    }
    private void Start()
    {
        reflectCount = maxReflectCount;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rigid.velocity;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            if (reflectCount < 0)
            {
                Destroy(gameObject);
            }
            var speed = lastVelocity.magnitude;
            var dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);

            rigid.velocity = dir.normalized * speed;
            reflectCount--;
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            damage = UnityEngine.Random.Range(3, 5);
            RectTransform rect = _hpBar.GetComponent<RectTransform>();
            rect.DOShakeAnchorPos(1f, 10, 10);
            player.PlayerDamage(damage);

            Destroy(gameObject);
        }
    }
}
