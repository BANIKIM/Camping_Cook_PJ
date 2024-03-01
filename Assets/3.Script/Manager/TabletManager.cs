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
        // ������ ���� Ȱ��ȭ�� ��Ÿ�� ���� ��� (�ִ� 3������)
        // idx�� ���� Ȱ��ȭ�� ����
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
        // Ȱ��ȭ�� ���� ������ �ʱ�ȭ
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

        // TextMeshProUGUI �迭�� ������ ���� ���� ����
        _starCount.text = halfActiveStarCount.ToString();
    }


}
