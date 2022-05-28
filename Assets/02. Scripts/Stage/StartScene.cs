using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartScene : MonoBehaviour
{
    private RectTransform _canvasTrm;
    private RectTransform _panelImage;
    private RectTransform _attributePanel;
    private RectTransform _attributeImage;

    PlayerAttack playerAttack;

    public bool _wind = false;
    public bool _fire = false;
    public bool _thunder = false;
    
    [SerializeField] private Image _fadePanel;

    //private RectTransform _panelImage;

    private Transform _player;
    private Animator _animator;

    private Vector3 dir;

    void Start()
    {
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _panelImage = _canvasTrm.Find("Start").GetComponent<RectTransform>();
        _attributePanel = _canvasTrm.Find("Propety").GetComponent<RectTransform>();
        _attributeImage = _attributePanel.Find("PropetyChoice").GetComponent <RectTransform>();

        //_clearImage = _panelImage.Find("").GetComponent<RectTransform>();

        _attributePanel.gameObject.SetActive(false);

        _animator = GameObject.Find("Player").GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        playerAttack = FindObjectOfType<PlayerAttack>();

        Image img = _panelImage.GetComponent<Image>();

        Sequence seq = DOTween.Sequence();

        seq.Append(_panelImage.DOAnchorPos(new Vector2(-494, -230) - new Vector2(0, 60f), 0.5f));
        seq.Append(_panelImage.DOAnchorPos(new Vector2(-494, -230) + new Vector2(0, 40f), 0.3f));
        seq.Append(_panelImage.DOAnchorPos(new Vector2(-494, -230), 0.4f));
    }

    public void Falling()
    {
        _animator.SetBool("Falling", true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_player.DOMoveY(3.5f, 0.5f));
        seq.Append(_player.DOMoveY(-15f, 2f));

        _attributePanel.gameObject.SetActive(true);

        PropetyChoice();
    }

    private void PropetyChoice()
    {
        Image img = _attributePanel.GetComponent<Image>();

        Sequence seq = DOTween.Sequence();

        seq.Append(img.DOFade(0.7f, 1));

        seq.Join(_attributeImage.DOAnchorPos(new Vector2(0, 150), 0.5f));
        seq.Append(_attributeImage.DOAnchorPos(new Vector2(0, -100), 0.3f));
        seq.Append(_attributeImage.DOAnchorPos(new Vector2(0, 0), 0.4f));
    }

    /*public void Wind()
    {
        playerAttack.WindMode();
        StartGame();
    }

    public void Fire()
    {
        playerAttack.FireMode();
        StartGame();
    }

    public void Thunder()
    {
        playerAttack.ThunderMode();
        StartGame();
    }*/

    public void StartGame()
    {
        Sequence seq = DOTween.Sequence();
        _fadePanel.gameObject.SetActive(true);
        seq.Append(_fadePanel.DOFade(1, 1));
        StartCoroutine(SceneMove(1.5f));
    }

    IEnumerator SceneMove(float sec)
    {
        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene(1);
    }
}
