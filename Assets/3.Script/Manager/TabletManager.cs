using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletManager : MonoBehaviour
{
    public static TabletManager instance = null;

    public UI_Star _ui_Star;
    public UI_ProgressCook _ui_ProgressCook;
    public UI_CookingTimer _ui_CookingTimer;


    public TextMeshProUGUI _levelText;
    public Slider _expSlider;


    [Header("Selected Recipe")]
    public Image _cookImg;
    public Sprite[] _cookAllImgs;
    public TextMeshProUGUI _cookText;
    public TextMeshProUGUI _difficultyText;
    public GameObject[] _cookingOrder;

    [Header("Home")]
    public TextMeshProUGUI _trophyCount;
    public TextMeshProUGUI _campingLv;
    public TextMeshProUGUI _userName;
    public Slider _campingExp;

    public GameObject[] _cookProgress;

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
        _idxTemp = idx;

    }

    public void RecipeBackBtn()
    {
        _cookingOrder[_idxTemp].SetActive(false);
    }

    #region GameStart

    public void UIStartGameEvent()
    {
        if (!GameManager.instance.isCookingStart) return;

        CookingProgress(true);
        _ui_CookingTimer.OnCookingTimer(true);
        _ui_ProgressCook.StartProgress();
    }



    #endregion

    #region GameEnd
    public void UIEndGameEvent()
    {
        if (GameManager.instance.isCookingStart) return;

        _ui_CookingTimer.OnCookingTimer(false);
        CookingProgress(false);
        _ui_ProgressCook.EndProgress();

    }
    #endregion

    public void CookingProgress(bool isActive)
    {
        _cookProgress[GameManager.instance._cookIdx].SetActive(isActive);
    }

}
