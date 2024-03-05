using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(UI_Star))]
[RequireComponent(typeof(UI_ProgressCook))]
[RequireComponent(typeof(UI_CookingTimer))]

public class TabletManager : MonoBehaviour
{
    public static TabletManager instance = null;

    [HideInInspector] public UI_Star _ui_Star;
    [HideInInspector] public UI_ProgressCook _ui_ProgressCook;
    [HideInInspector] public UI_CookingTimer _ui_CookingTimer;

    // ===============================================

    // Tablet AudioSource 
    [SerializeField] private AudioSource _audioSource;

    [Header("Home")]
    public TextMeshProUGUI _userName;
    public TextMeshProUGUI _trophyCount;
    public TextMeshProUGUI _campingLv;
    public Slider _campingExp;

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
