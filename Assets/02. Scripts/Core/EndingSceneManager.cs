using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingSceneManager : MonoBehaviour
{
    public Text currentScoreTxt;
    Boss boss;

    private void Start()
    {
        

        currentScoreTxt.DOText($"Today Hunts : <{boss.Score}>", 2f);
    }
}
