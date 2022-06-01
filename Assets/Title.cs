using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Title : MonoBehaviour
{
    private Transform _title;

    private void Awake()
    {
        _title = GameObject.Find("Title").GetComponent<Transform>();
    }

    void Start()
    {
        StartCoroutine(TitleMove());
    }

    IEnumerator TitleMove()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Sequence seq = DOTween.Sequence();

            seq.Append(_title.DOScale(new Vector3(0.9f, 0.9f, 1), 0.5f));
            seq.Append(_title.DOScale(new Vector3(0.8f, 0.8f, 1), 0.5f));
            seq.Append(_title.DOScale(new Vector3(0.7f, 0.7f, 1), 0.5f));

            DOTween.Kill(seq);
        }
    }
}
