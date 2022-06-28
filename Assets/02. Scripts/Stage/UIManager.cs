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

    private RectTransform escapePanel;

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
        escapePanel = GameObject.Find("Canvas/Panel").GetComponent<RectTransform>();
    }

    public void Escape()
    {

        StartCoroutine(EscapeCo());
    }

    IEnumerator EscapeCo()
    {
        escapePanel.DOScaleX(1, 0.5f);

        yield return new WaitForSecondsRealtime(0.6f);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        print("A");
        StartCoroutine(ResumeCo());
    }

    IEnumerator ResumeCo()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        escapePanel.DOScaleX(0, 0.5f);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        StartCoroutine(QuitCo());
    }

    IEnumerator QuitCo()
    {
        curtain.DOAnchorPosX(960, 0.5f);
        curtain_1.DOAnchorPosX(-960, 0.5f);

        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        curtain.DOAnchorPosX(1920, 1f);
        curtain_1.DOAnchorPosX(-1920, 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            Escape();
        }
    }
}
