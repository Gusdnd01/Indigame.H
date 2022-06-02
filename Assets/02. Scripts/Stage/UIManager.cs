using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private RectTransform curtain;
    private RectTransform curtain_1;

    private void Awake()
    {
        curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();
    }
    void Start()
    {
        CurtainMove();
    }

    public void CurtainMove()
    {
        curtain.DOAnchorPosX(1920, 1f);
        curtain_1.DOAnchorPosX(-1920, 1f);
    }

    public void CurtainReverse()
    {
        curtain.DOAnchorPosX(960, 1f);
        curtain_1.DOAnchorPosX(-960, 1f);
    }

}
