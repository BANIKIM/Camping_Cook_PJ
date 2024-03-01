using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletManager : MonoBehaviour
{
    public static TabletManager instance = null;

    [Header("Recipe")]
    public Image _cookImg;
    public Sprite[] _cookAllImgs;
    public TextMeshProUGUI _cookText;
    public TextMeshProUGUI _difficultyText;
    public GameObject[] _cookingOrder;


    [Header("Star")]
    public GameObject[] _starObj;
    public Sprite _fullStarImg;
    public int[] _currentStarCount = new int[5] { 0, 0, 0, 0, 0 };

    [Header("Home")]
    public TextMeshProUGUI _userName;
    public TextMeshProUGUI _starCount;
    public TextMeshProUGUI _trophyCount;
    public TextMeshProUGUI _campingLv;
    public TextMeshProUGUI _campingExp;


    public UIExperience _uiExperience;

    // =============================



    public GameObject updateObject2;

    public int activeStarCount = 0;

    [SerializeField]
    private UpdateCookUI update_CookUI2;

    public UpdateCookUI Update_CookUI2
    {
        get
        {
            return update_CookUI2;
        }
    }

    [SerializeField]
    private CookingTimer cookingTimer;

    public CookingTimer CookingTimer
    {
        get
        {
            return cookingTimer;
        }
    }



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
        TryGetComponent(out _uiExperience);
        TryGetComponent(out update_CookUI2);
    }





    private void Update()
    {
        UpdateActiveStarCount();
    }


    public void StarUpdate(int idx)
    {
        // 레벨에 따라 활성화할 스타의 개수 계산 (최대 3개까지)
        // idx는 별을 활성화할 개수
        if (_currentStarCount[GameManager.instance._cookIdx] < idx)
        {
            for (int i = 0; i < idx; i++)
            {
                _starObj[GameManager.instance._cookIdx].transform.GetChild(i).GetComponent<Image>().sprite = _fullStarImg;

            }
            _currentStarCount[GameManager.instance._cookIdx] = idx;
        }

    }


    private void UpdateActiveStarCount()
    {
        // 활성화된 별의 갯수를 초기화
        activeStarCount = 0;



        for (int i = 0; i < _starObj.Length; i++)
        {
            for (int j = 0; j < _starObj[i].transform.childCount; j++)
            {
                if (_starObj[i].transform.GetChild(j).gameObject.activeSelf)
                {
                    activeStarCount++;
                }
            }
        }
        int halfActiveStarCount = activeStarCount / 2;

        // TextMeshProUGUI 배열에 반으로 나눈 값을 설정
        _starCount.text = halfActiveStarCount.ToString();
    }


}
