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

    private void Awake()
    {
        curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();
    }

    private void Start()
    {
        curtain.DOAnchorPosX(1920, 0.5f);
        curtain_1.DOAnchorPosX(-1920, 0.5f);
    }
}
