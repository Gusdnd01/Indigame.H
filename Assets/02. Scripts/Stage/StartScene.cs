using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartScene : MonoBehaviour
{
    public static StartScene instance;

    private RectTransform _canvasTrm;
    private RectTransform _panelImage;
    private RectTransform _attributePanel;
    private RectTransform _attributeImage;

    private RectTransform _windPanel;
    private RectTransform _firePanel;
    private RectTransform _thunderPanel;
    private RectTransform _waterPanel;
    private RectTransform _startButton;

    private RectTransform _curtain;
    private RectTransform _curtain_1;

    private Text explainTxt;

    private RectTransform _attributeTrm;

    PlayerAttack playerAttack;

    public bool _wind = false;
    public bool _fire = false;
    public bool _thunder = false;
    public bool _water = false;

    //private RectTransform _panelImage;

    private Transform _player;
    private Animator _animator;

    private Vector3 dir;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Multuple instance is running");
        }
        instance = this;
    }

    void Start()
    {
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _panelImage = _canvasTrm.Find("Start").GetComponent<RectTransform>();
        _attributePanel = _canvasTrm.Find("Propety").GetComponent<RectTransform>();
        _attributeImage = _attributePanel.Find("PropetyChoice").GetComponent <RectTransform>();

        _attributeTrm = _canvasTrm.Find("AttributePanel/attributePanel").GetComponent<RectTransform>();
        _startButton = _canvasTrm.Find("AttributePanel/StartButton").GetComponent<RectTransform>();

        _curtain = GameObject.Find("Canvas/CurtainManager/Curtain").GetComponent<RectTransform>();
        _curtain_1 = GameObject.Find("Canvas/CurtainManager/Curtain_1").GetComponent<RectTransform>();

        explainTxt = _canvasTrm.Find("AttributePanel/ExplainTxt").GetComponent<Text>();

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

        seq.Join(_attributeImage.DOAnchorPos(new Vector2(-450, 150), 0.5f));
        seq.Append(_attributeImage.DOAnchorPos(new Vector2(-450, -100), 0.3f));
        seq.Append(_attributeImage.DOAnchorPos(new Vector2(-450, 0), 0.4f));
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

    public void WindPanel()
    {
        explainTxt.DOText("", 0.1f);
        Image img = _attributeTrm.GetComponent<Image>();
        img.DOFade(0.5f, 0.1f);

        explainTxt.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(0, 0.5f));
        seq.Append(_attributeTrm.DOScaleY(900, 0.5f));
        seq.Append(explainTxt.DOText("This is Wind", 2f));

        _wind = true;
        _fire = false;
        _thunder = false;
        _water = false;

        seq.Append(_startButton.DOAnchorPos(new Vector2(0, -400), 1f));
    }

    public void FirePanel()
    {
        explainTxt.DOText("", 0.1f);
        Image img = _attributeTrm.GetComponent<Image>();
        img.DOFade(0.5f, 0.1f);

        explainTxt.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(0, 0.5f));
        seq.Append(_attributeTrm.DOScaleY(900, 0.5f));
        seq.Append(explainTxt.DOText("This is Fire", 2f));

        _wind = false;
        _fire = true;
        _thunder = false;
        _water = false;

    }

    public void ThunderPanel()
    {
        explainTxt.DOText("", 0.1f);
        Image img = _attributeTrm.GetComponent<Image>();
        img.DOFade(0.5f, 0.1f);

        explainTxt.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(0, 0.5f));
        seq.Append(_attributeTrm.DOScaleY(900, 0.5f));
        seq.Append(explainTxt.DOText("This is Thunder", 2f));

        _wind = false;
        _fire = false;
        _thunder = true;
        _water = false;

    }

    public void WaterPanel()
    {
        explainTxt.DOText("", 0.1f);

        Image img = _attributeTrm.GetComponent<Image>();
        img.DOFade(0.5f, 0.1f);

        explainTxt.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(0, 0.5f));
        seq.Append(_attributeTrm.DOScaleY(900, 0.5f));
        seq.Append(explainTxt.DOText("This is Water", 2f));
        _wind = false;
        _fire = false;
        _thunder = false;
        _water = true;
    }

    public void StartGame()
    {
        _curtain.DOAnchorPosX(960, 1f);
        _curtain_1.DOAnchorPosX(-960, 1f);

        StartCoroutine(SceneMove(1.5f));
    }

    IEnumerator SceneMove(float sec)
    {
        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene("Intro");
    }
}