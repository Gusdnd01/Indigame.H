using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    Sequence sequence;

    void Start()
    {
        sequence = DOTween.Sequence();

        sequence.Append(_fadePanel.DOFade(0, 1f));
    }

    void Update()
    {
        
    }
}
