using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletManager : MonoBehaviour
{
    public static TabletManager instance = null;

    [HideInInspector] public UI_Star _ui_Star;
    [HideInInspector] public UI_ProgressCook _ui_ProgressCook;
    [HideInInspector] public UI_CookingTimer _ui_CookingTimer;


    public TextMeshProUGUI _levelText;
    public Slider _expSlider;

    [SerializeField] private AudioSource _audioSource;

    [Header("Selected Recipe")]
    public Image _cookImg;
    public Sprite[] _cookAllImgs;
    public TextMeshProUGUI _difficultyText;
    public GameObject[] _cookingOrder;
    [SerializeField] private TextMeshProUGUI _recipeName;


    [Header("Home")]
    public TextMeshProUGUI _trophyCount;
    public TextMeshProUGUI _campingLv;
    public TextMeshProUGUI _userName;
    public Slider _campingExp;

    private int _idxTemp;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
    }

    private void Start()
    {
        TryGetComponent(out _ui_Star);
        TryGetComponent(out _ui_CookingTimer);
        TryGetComponent(out _ui_ProgressCook);
    }

    public void SelectRecipe(int idx)
    {


        _cookImg.sprite = _cookAllImgs[idx];
        _cookingOrder[idx].SetActive(true);
        _recipeName.text = _ui_ProgressCook._cookNameArr[idx];

    }

    public void RecipeBackBtn()
    {
        _cookingOrder[GameManager.instance._cookIdx].SetActive(false);
    }

    #region GameStart

    public void UIStartGameEvent()
    {
        if (!GameManager.instance.isCookingStart) return;

        _audioSource.PlayOneShot(AudioManager.instance._sfxClips[(int)SFX_List.CookStart]);
        _ui_ProgressCook.StartProgress(GameManager.instance._cookIdx);
        _ui_CookingTimer.OnCookingTimer(true);
        // _ui_ProgressCook.StartProgress();
    }



    #endregion

    #region GameEnd

    public void UIEndGameEvent()
    {
        if (GameManager.instance.isCookingStart) return;

        _ui_CookingTimer.OnCookingTimer(false);

        _ui_ProgressCook.EndProgress();

    }

    #endregion

    public void BtnSound()
    {
        _audioSource.PlayOneShot(AudioManager.instance._sfxClips[(int)SFX_List.Btn]);
    }

}
