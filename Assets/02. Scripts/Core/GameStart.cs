using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameStart : MonoBehaviour
{
    CameraManager cameraManager;
    private RectTransform BossNamePanel;
    void Start()
    {
        BossNamePanel = GameObject.Find("Canvas/Panel").GetComponent<RectTransform>();
        cameraManager = GetComponent<CameraManager>();
        StartCoroutine(CamActive(3f));

        Sequence seq = DOTween.Sequence();

        seq.Append(BossNamePanel.DOAnchorPosX(-50, 0.5f));
        seq.Append(BossNamePanel.DOAnchorPosX(0, 2f));
        seq.Append(BossNamePanel.DOAnchorPosX(1920, 0.5f));
    }

    IEnumerator CamActive(float sec) 
    {
        CameraManager.instance.BossCamActive();
        yield return new WaitForSeconds(sec);
        CameraManager.instance.PlayerCamActive();
    }
}
