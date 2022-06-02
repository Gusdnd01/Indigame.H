using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    private RectTransform _MainMenuButton;

    private void Awake()
    {
        _MainMenuButton = GameObject.Find("MainMenuButton").GetComponent<RectTransform>();
    }

    private void Start()
    {
        _MainMenuButton.DOAnchorPosY(105, 0.5f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
