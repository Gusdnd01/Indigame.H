using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneMove : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Image panel;

    void Start()
    {
        
        if(PlayerPrefs.GetInt("Stage") == 5)
        {
            StartCoroutine(SceneMove_2());
        }

        else
        {
            StartCoroutine(SceneMove_1());
        }
    }

    IEnumerator SceneMove_1()
    {
        txt.DOText($"Hunt Count : {PlayerPrefs.GetInt("Stage")}", 1f);
        yield return new WaitForSeconds(1f);
        panel.DOFade(1, 3f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Play");
    }

    IEnumerator SceneMove_2()
    {
        txt.DOText($"Hunt Count : {PlayerPrefs.GetInt("Stage")}...?", 1.5f);
        yield return new WaitForSeconds(1f);
        panel.DOFade(1, 3f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }
}
