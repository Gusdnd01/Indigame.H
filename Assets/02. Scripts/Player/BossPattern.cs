using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class BossPattern : MonoBehaviour
{
    [SerializeField] private GameObject bulletA;
    [SerializeField] private GameObject bulletB;

    [SerializeField] private GameObject warningPrefab;

    [SerializeField] private GameObject attackTrm;
    [SerializeField] private Transform attackPos;
    private GameObject attackPrefab;
    LastBoss lB;

    Animator anim;

    public int sec = 5;

    List<Action> functionTable = new List<Action>();
    List<Action> functionBox = new List<Action>();

    SlashSin slashObject;
    void Awake()
    {
        anim = GetComponent<Animator>();
        slashObject = GetComponent<SlashSin>();
        lB = GetComponent<LastBoss>();

        slashObject.shakeSpeed = 0;
        attackPrefab = attackTrm.gameObject;
        Invoke("Skill", 5f);
    }

    private void Start()
    {
        functionTable.Add(BossPattern_1);
        functionTable.Add(BossPattern_2);
        functionTable.Add(BossPattern_3);
    }
    int index = 0;
    private void Update()
    {
        if (lB.currentHp <= lB.maxHp / 2 && index == 0)
        {
            index++;
            StartCoroutine(Page2());
        }
    }
    void Skill()
    {
        print("AA");
        slashObject.shakeSpeed = 1;
        Action callback = null;
        if (functionBox.Count == 0)
        {
            print("0");
            foreach (var a in functionTable)
            {
                functionBox.Add(a);
            }
            int ran = Random.Range(0, functionBox.Count);
            callback = functionBox[ran];
            functionBox.RemoveAt(ran);
        }
        else
        {
            int ran = Random.Range(0, functionBox.Count);
            callback = functionBox[ran];
            functionBox.RemoveAt(ran);
        }
        print(callback);
        callback?.Invoke();
        Invoke("Skill", sec);
    }

    IEnumerator Page2()
    {
        CameraManager.instance.BossDeathCamActive();
        sec = 10;
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("page2");
        yield return new WaitForSeconds(2.5f);
        CameraManager.instance.PlayerCamActive();
        sec = 3;
    }

    void BossPattern_1()
    {
        StartCoroutine(Pattern1(4f));
    }


    public void BossPattern_2()
    {
        anim.SetTrigger("isAttack");
        float grid = 180f / 18;
        float angle = 0f;
        Quaternion rot = Quaternion.Euler(0,0,0);
        for (int i = 0; i < 18; i++)
        {
            rot = Quaternion.Euler(0, 0, angle);
            Instantiate(bulletB, attackPos.position, rot);
            angle += grid;
        }

    }

    void BossPattern_3()
    {
        StartCoroutine(SpawnBulletPattern());
        
    }

    void SM()
    {
        Sequence seq = DOTween.Sequence();

        float positionY = Random.Range(-6, 4);
        GameObject alterLineClone = Instantiate(warningPrefab, new Vector3(0, positionY, 0), Quaternion.identity);

        seq.AppendInterval(1f);

        seq.AppendCallback(() => {
            Destroy(alterLineClone);

            Vector3 meteoritePosition = new Vector3(20, positionY, 0);
            Instantiate(bulletA, meteoritePosition, Quaternion.identity);
        });
    }

    IEnumerator Pattern1(float sec)
    {
        GameObject attack = Instantiate(attackPrefab, attackPos.position, attackPos.rotation);

        yield return new WaitForSeconds(sec);

        Destroy(attack);
    }

    IEnumerator SpawnBulletPattern()
    {
        for(int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, 3);
            for(int k = 0; k < rand; k++)
            {
                SM();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
