using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingSceneManager : MonoBehaviour
{
    public Text currentScoreTxt;
    private int currentScore;

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("Score", 0);

        currentScoreTxt.DOText($"Today Hunts : <{currentScore}>", 2f);
    }
}
