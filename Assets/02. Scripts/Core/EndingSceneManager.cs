using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingSceneManager : MonoBehaviour
{
    public Text currentScoreTxt;
    public Text bestScoreTxt;

    private void Start()
    {
        bestScoreTxt.DOText($"Best Hunts : <{PlayerPrefs.GetInt("Score")}>", 2f);
        currentScoreTxt.DOText($"Today Hunts : <{PlayerPrefs.GetInt("Best")}>", 2f);
    }
}
