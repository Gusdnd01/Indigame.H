using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Curtain : MonoBehaviour
{
    private RectTransform _curtainF;
    private RectTransform _curtainS;

    private void Awake()
    {
        _curtainF = GameObject.Find("Canvas/curtainF").GetComponent<RectTransform>();
        _curtainS = GameObject.Find("Canvas/curtainS").GetComponent<RectTransform>();

        _curtainF.DOAnchorPosY(540, 1f);
        _curtainS.DOAnchorPosY(-540, 1f);
    }

    void Start()
    {
        
    }
}
