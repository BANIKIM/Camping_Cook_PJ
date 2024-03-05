using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Tablet_Star))]
[RequireComponent(typeof(Tablet_ProgressCook))]
[RequireComponent(typeof(Tablet_CookingTimer))]

public class TabletManager : MonoBehaviour
{
    public static TabletManager instance = null;

    [HideInInspector] public Tablet_Star _ui_Star;
    [HideInInspector] public Tablet_ProgressCook _ui_ProgressCook;
    [HideInInspector] public Tablet_CookingTimer _ui_CookingTimer;

    // ===============================================

    // Tablet AudioSource 
    [SerializeField] private AudioSource _audioSource;

    [Header("Home")]
    public TextMeshProUGUI _userNameText;
    public TextMeshProUGUI _trophyCountText;
    public TextMeshProUGUI _campingLvText;
    public Slider _campingExpSlider;
    public TextMeshProUGUI _coinCountText;


    public TextMeshProUGUI _gameModText;

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



    }

    public void RecipeBackBtn()
    {

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
