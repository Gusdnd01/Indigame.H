using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextSSiDen : MonoBehaviour
{
    private Text txt;
    [SerializeField] private string Txt;
    [SerializeField] private string Txt_1;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    void Start()
    {
        StartCoroutine(TextChange(4f));
    }

    IEnumerator TextChange(float sec)
    {
        yield return new WaitForSeconds(1f);

        Sequence seq = DOTween.Sequence();

        seq.Append(txt.DOText(Txt, sec));
        seq.Append(txt.DOText("", 0.1f));
        seq.Append(txt.DOText(Txt_1, sec));
    }
}
