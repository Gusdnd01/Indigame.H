using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("best", bestScore);
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int SetScore(int value)
    {
        currentScore = value;
        PlayerPrefs.SetInt("current", value);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("best", bestScore);
        }
        return value;
    }
}
