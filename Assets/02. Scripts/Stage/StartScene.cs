using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartScene : MonoBehaviour
{
    #region º¯¼ö
    public static StartScene instance;

    private RectTransform _canvasTrm;
    private RectTransform _panelImage;
    private RectTransform _attributePanel;
    private RectTransform _attributeImage;
    private RectTransform _howToPlayPanel;

    private Button startButton;
    private Button howToPlayButton;

    Material material;
    private bool isDissolve = false;
    private bool isDissolveBack = false;
    float fade = 1f;

    private RectTransform _startButton;
    private RectTransform _escapeButton;
    private RectTransform _quitButton;

    private Button _windButton;
    private Button _fireButton;
    private Button _thunderButton;
    private Button _waterButton;

    private RectTransform _curtain;
    private RectTransform _curtain_1;

    private Text explainTxt;
    private Text explainTxt_1;
    private Text explainTxt_2;

    private RectTransform _attributeTrm;
    private SpriteRenderer _title;

    PlayerAttack playerAttack;

    public bool _wind = false;
    public bool _fire = false;
    public bool _thunder = false;
    public bool _water = false;

    private bool _isFall = false;
    private bool _isNotStart = false;

    private AudioSource _audioSource;

    //private RectTransform _panelImage;

    private Transform _player;
    private Animator _animator;

    private Vector3 dir;
    #endregion
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
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Stage", 0);
        #region °´Ã¼ Å½»ö ½ºÅ©¸³Æ®
        _canvasTrm = GameObject.Find("Canvas").GetComponent<RectTransform>();
        _panelImage = _canvasTrm.Find("Start").GetComponent<RectTransform>();
        _howToPlayPanel = _canvasTrm.Find("HowToPlay").GetComponent<RectTransform>();
        _attributePanel = _canvasTrm.Find("Propety").GetComponent<RectTransform>();
        _attributeImage = _attributePanel.Find("PropetyChoice").GetComponent <RectTransform>();

        _attributeTrm = _canvasTrm.Find("AttributePanel/attributePanel").GetComponent<RectTransform>();
        _startButton = _canvasTrm.Find("AttributePanel/StartButton").GetComponent<RectTransform>();
        _quitButton = _canvasTrm.Find("AttributePanel/QuitButton").GetComponent<RectTransform>();
        _escapeButton = _canvasTrm.Find("AttributePanel/EscapeButton").GetComponent<RectTransform>();

        _windButton = _attributeImage.Find("Wind").GetComponent<Button>();
        _fireButton = _attributeImage.Find("Fire").GetComponent<Button>();
        _thunderButton = _attributeImage.Find("Thunder").GetComponent<Button>();
        _waterButton = _attributeImage.Find("Water").GetComponent<Button>();

        _curtain = GameObject.Find("Canvas/CurtainManager/Curtain").GetComponent<RectTransform>();
        _curtain_1 = GameObject.Find("Canvas/CurtainManager/Curtain_1").GetComponent<RectTransform>();

        _curtain.DOAnchorPosX(1920, 0.5f);
        _curtain_1.DOAnchorPosX(-1920, 0.5f);

        explainTxt = _canvasTrm.Find("AttributePanel/ExplainTxt").GetComponent<Text>();
        explainTxt_1 = _canvasTrm.Find("AttributePanel/ExplainTxt_1").GetComponent<Text>();
        explainTxt_2 = _canvasTrm.Find("AttributePanel/ExplainTxt_2").GetComponent<Text>();
        _title = GameObject.Find("Title").GetComponent<SpriteRenderer>();
        material = _title.GetComponent<SpriteRenderer>().material;

        _audioSource = GetComponent<AudioSource>();

        //_clearImage = _panelImage.Find("").GetComponent<RectTransform>();

        _attributePanel.gameObject.SetActive(false);

        _animator = GameObject.Find("Player").GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        playerAttack = FindObjectOfType<PlayerAttack>();

        startButton = _panelImage.Find("Button").GetComponent<Button>();
        howToPlayButton = _panelImage.Find("Button (1)").GetComponent<Button>();
        #endregion
        Image img = _panelImage.GetComponent<Image>();

        Sequence seq = DOTween.Sequence();

        seq.Append(_panelImage.DOAnchorPos(new Vector2(-494, -230) - new Vector2(0, 60f), 0.5f));
        seq.Append(_panelImage.DOAnchorPos(new Vector2(-494, -230) + new Vector2(0, 40f), 0.3f));
        seq.Append(_panelImage.DOAnchorPos(new Vector2(-494, -230), 0.4f));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _isNotStart == false)
        {
            StartCoroutine(Exit());
        }

        if (isDissolve)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolve = false;
            }

            material.SetFloat("_Dissolve", fade);
        }

        if (isDissolveBack)
        {
            fade += Time.deltaTime;

            if (fade >= 0f)
            {
                fade = 1f;
                isDissolveBack = false;
            }

            material.SetFloat("_Dissolve", fade);
        }
    }
    
    public void EscapeButtonDown()
    {
        isDissolveBack = true;

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeImage.DOAnchorPosY(-800, 0.5f));
        seq.Join(_startButton.DOAnchorPosY(-600, 0.5f));
        seq.Join(_quitButton.DOAnchorPosY(-660, 0.5f));
        seq.Join(_escapeButton.DOAnchorPosY(1000, 0.5f));
        seq.Join(_attributePanel.DOAnchorPosY(-1080, 0.5f));
        explainTxt.DOText("", 0.1f);
        explainTxt_1.DOText("", 0.1f);
        explainTxt_2.DOText("", 0.1f);

        _attributeTrm.gameObject.SetActive(false);
        _isNotStart = false;

        _windButton.interactable = true;
        _fireButton.interactable = true;
        _thunderButton.interactable = true;
        _waterButton.interactable = true;
    }

    public void Falling()
    {
        _animator.SetBool("Falling", true);
        isDissolve = true;
        Sequence seq = DOTween.Sequence();

        if(_isFall == false)
        {
            seq.Append(_player.DOMoveY(3.5f, 0.5f));
            seq.Append(_player.DOMoveY(-15f, 2f));

            _isFall = true;
        }
        _attributePanel.gameObject.SetActive(true);

        PropetyChoice();
    }

    public void HowToPlay()
    {
        startButton.interactable = false;
        howToPlayButton.interactable = false;

        _howToPlayPanel.DOScale(new Vector2(1, 1), 1f);
    }

    public void HowToPlayExit()
    {
        startButton.interactable = true;
        howToPlayButton.interactable = true;

        _howToPlayPanel.DOScale(new Vector2(0, 0), 1f);
    }

    private void PropetyChoice()
    {
        _isNotStart = true;
        Sequence seq = DOTween.Sequence();

        seq.Append(_attributePanel.DOAnchorPosY(0, 0.5f));

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
        explainTxt_1.DOText("", 0.1f);
        explainTxt_2.DOText("", 0.1f);
        _audioSource.Play();
        

        explainTxt.gameObject.SetActive(true);
        explainTxt_1.gameObject.SetActive(true);
        explainTxt_2.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(1, 0.5f));
        seq.Append(explainTxt_2.DOColor(Color.green, 0.5f));
        seq.Append(explainTxt_2.DOText("Wind", 0.1f));
        seq.Append(explainTxt.DOText("Speed : Normal", 1f));
        seq.Append(explainTxt_1.DOText("Damage : 1 ~ 20", 1f));
        seq.Append(_startButton.DOAnchorPosY(-400, 0.5f));
        seq.Append(_escapeButton.DOAnchorPosY(900, 0.5f));
        seq.Append(_quitButton.DOAnchorPosY(0, 0.5f));

        _wind = true;
        _fire = false;
        _thunder = false;
        _water = false;

        _windButton.interactable = false;
        _fireButton.interactable = false;
        _thunderButton.interactable = false;
        _waterButton.interactable = false;
    }

    public void FirePanel()
    {
        explainTxt.DOText("", 0.1f);
        explainTxt_1.DOText("", 0.1f);
        explainTxt_2.DOText("", 0.1f);
        _audioSource.Play();

        explainTxt.gameObject.SetActive(true);
        explainTxt_1.gameObject.SetActive(true);
        explainTxt_2.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(1, 0.5f));
        seq.Append(explainTxt_2.DOColor(Color.red, 0.5f));
        seq.Append(explainTxt_2.DOText("Fire", 0.1f));
        seq.Append(explainTxt.DOText("Speed : Slow", 1f));
        seq.Append(explainTxt_1.DOText("Damage : 20", 1f));
        seq.Append(_startButton.DOAnchorPosY(-400, 0.5f));
        seq.Append(_escapeButton.DOAnchorPosY(900, 0.5f));
        seq.Append(_quitButton.DOAnchorPosY(0, 0.5f));

        _wind = false;
        _fire = true;
        _thunder = false;
        _water = false;

        _windButton.interactable = false;
        _fireButton.interactable = false;
        _thunderButton.interactable = false;
        _waterButton.interactable = false;
    }

    public void ThunderPanel()
    {
        explainTxt.DOText("", 0.1f);
        explainTxt_1.DOText("", 0.1f);
        explainTxt_2.DOText("", 0.1f);
        _audioSource.Play();

        explainTxt.gameObject.SetActive(true);
        explainTxt_1.gameObject.SetActive(true);
        explainTxt_2.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(1, 0.5f));
        seq.Append(explainTxt_2.DOColor(Color.yellow, 0.5f));
        seq.Append(explainTxt_2.DOText("Thunder", 0.1f));
        seq.Append(explainTxt.DOText("Speed : Normal", 1f));
        seq.Append(explainTxt_1.DOText("Damage : 5 ~ 15", 1f));
        seq.Append(_startButton.DOAnchorPosY(-400, 0.5f));
        seq.Append(_escapeButton.DOAnchorPosY(900, 0.5f));
        seq.Append(_quitButton.DOAnchorPosY(0, 0.5f));

        _wind = false;
        _fire = false;
        _thunder = true;
        _water = false;

        _windButton.interactable = false;
        _fireButton.interactable = false;
        _thunderButton.interactable = false;
        _waterButton.interactable = false;
    }

    public void WaterPanel()
    {
        explainTxt.DOText("", 0.1f);
        explainTxt_1.DOText("", 0.1f);
        explainTxt_2.DOText("", 0.1f);
        _audioSource.Play();


        explainTxt.gameObject.SetActive(true);
        explainTxt_1.gameObject.SetActive(true);
        explainTxt_2.gameObject.SetActive(true);
        _attributeTrm.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_attributeTrm.DOScaleY(1, 0.5f));
        seq.Append(explainTxt_2.DOColor(Color.blue, 0.5f));
        seq.Append(explainTxt_2.DOText("Water", 0.1f));
        seq.Append(explainTxt.DOText("Speed : Fast", 1f));
        seq.Append(explainTxt_1.DOText("Damage : 1 ~ 5", 1f));
        seq.Append(_startButton.DOAnchorPosY(-400, 0.5f));
        seq.Append(_escapeButton.DOAnchorPosY(900, 0.5f));
        seq.Append(_quitButton.DOAnchorPosY(0, 0.5f));

        _wind = false;
        _fire = false;
        _thunder = false;
        _water = true;

        _windButton.interactable = false;
        _fireButton.interactable = false;
        _thunderButton.interactable = false;
        _waterButton.interactable = false;
    }

    public void StartGame()
    {
        _curtain.DOAnchorPosX(960, 1f);
        _curtain_1.DOAnchorPosX(-960, 1f);
        _audioSource.Play();

        StartCoroutine(SceneMove(1.5f));
    }

    public void AttributeQuitButton()
    {
        _startButton.DOAnchorPosY(-600, 0.5f);
        _quitButton.DOAnchorPosY(-660, 0.5f);
        _attributeTrm.DOScaleY(0, 0.5f);

        explainTxt_2.DOText("", 0.1f);
        explainTxt.DOText("", 0.1f);
        explainTxt_1.DOText("", 0.1f);

        _windButton.interactable = true;
        _fireButton.interactable = true;
        _thunderButton.interactable = true;
        _waterButton.interactable = true;
    }

    IEnumerator SceneMove(float sec)
    {
        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene(1);
    }

    IEnumerator Exit()
    {
        _curtain.DOAnchorPosX(960, 0.5f);
        _curtain_1.DOAnchorPosX(-960, 0.5f);
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}