using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LastBossUIManager : MonoBehaviour
{
    private RectTransform curtain;
    private RectTransform curtain_1;
    private RectTransform escapePanel;
    private void Awake()
    {
        curtain = GameObject.Find("Canvas/Curtain").GetComponent<RectTransform>();
        curtain_1 = GameObject.Find("Canvas/Curtain_1").GetComponent<RectTransform>();
        escapePanel = GameObject.Find("Canvas/Panel_1").GetComponent<RectTransform>();
    }
    void Start()
    {
        curtain.DOAnchorPosX(1920, 0.5f);
        curtain_1.DOAnchorPosX(-1920, 0.5f);
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }
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
}
