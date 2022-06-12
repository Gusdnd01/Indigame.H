using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingSceneManager : MonoBehaviour
{
    public Text currentScoreTxt;
    public Text bestScoreTxt;
    int currentScore;
    int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("best", 0);
        bestScoreTxt.DOText($"Best Hunts : <{bestScore}>", 2f);
        currentScore = PlayerPrefs.GetInt("current", 0);
        currentScoreTxt.DOText($"Today Hunts : <{currentScore}>", 2f);
    }
}
