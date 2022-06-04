using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CurtainManager : MonoBehaviour
{
    private RectTransform _curtain;
    private RectTransform _curtain_1;

    private void Awake()
    {
        _curtain = GameObject.Find("Canvas/CurtainManager/Curtain").GetComponent<RectTransform>();
        _curtain_1 = GameObject.Find("Canvas/CurtainManager/Curtain_1").GetComponent<RectTransform>();
    }

    void Start()
    {
        _curtain.DOAnchorPosX(1920, 1f);
        _curtain_1.DOAnchorPosX(-1920, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(FadeIn(4.25f));
    }


    public void MainMenu()
    {
        StartCoroutine(MoveMenu(2.5f));
    }

    public void SkipIntro()
    {
        StartCoroutine(Skip());
    }

    IEnumerator FadeIn(float sec)
    {
        yield return new WaitForSeconds(sec);
        _curtain.DOAnchorPosX(960, 1f);
        _curtain_1.DOAnchorPosX(-960, 1f);
    }

    IEnumerator Skip()
    {
        _curtain.DOAnchorPosX(960, 1f);
        _curtain_1.DOAnchorPosX(-960, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    IEnumerator MoveMenu(float sec)
    {
        _curtain.DOAnchorPosX(960, 1f);
        _curtain_1.DOAnchorPosX(-960, 1f);
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(0);
    }
}
