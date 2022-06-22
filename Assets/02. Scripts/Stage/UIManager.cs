using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    private RectTransform curtain;
    private RectTransform curtain_1;

    int bossIndex;
    GameObject boss;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossPrefab2;
    [SerializeField] private GameObject bossPrefab3;
    [SerializeField] private Transform bossTransform;

    private void Awake()
    {
        bossIndex = UnityEngine.Random.Range(0, 3);

        if (bossIndex == 0)
        {
            boss = bossPrefab;
            Instantiate(boss, bossTransform.position, bossTransform.rotation);
        }
        else if (bossIndex == 1)
        {
            boss = bossPrefab2;
            Instantiate(boss, bossTransform.position, bossTransform.rotation);
        }
        else
        {
            boss = bossPrefab3;
            Instantiate(boss, bossTransform.position, bossTransform.rotation);
        }

        curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();
    }

    private void Start()
    {
        curtain.DOAnchorPosX(1920, 0.5f);
        curtain_1.DOAnchorPosX(-1920, 0.5f);
    }
}
