using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject[] Star;
    public GameObject[] Star2;
    public TextMeshProUGUI[] StartCount;


    public GameObject updateObject;
    public GameObject updateObject2;

    public GameObject dishSpawnPoint;

    public int activeStarCount = 0;
    public bool isCookingStarted = false;

    public float Exp = 100;
    public int Num = 0;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private UpdateCookUI update_CookUI;


    public UpdateCookUI Update_CookUI
    {
        get
        {
            return update_CookUI;
        }
    }
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


    [SerializeField]
    private UIExperience _uiExperience;

    private void Update()
    {
        UpdateActiveStarCount();
    }
    public void OnStar(int idx)
    {
        // 레벨에 따라 활성화할 스타의 개수 계산 (최대 3개까지)
        for (int i = 0; i < idx; i++)
        {
            Star[Num].transform.GetChild(i).gameObject.SetActive(true);
            Star2[Num].transform.GetChild(i).gameObject.SetActive(true);
        }

    }


    private void UpdateActiveStarCount()
    {
        // 활성화된 별의 갯수를 초기화
        activeStarCount = 0;

        // 각 요리에 대해 활성화된 별의 갯수를 계산하여 합산
        for (int i = 0; i < Star.Length; i++)
        {
            for (int j = 0; j < Star[i].transform.childCount; j++)
            {
                if (Star[i].transform.GetChild(j).gameObject.activeSelf)
                {
                    activeStarCount++;
                }
            }
        }

        for (int i = 0; i < Star2.Length; i++)
        {
            for (int j = 0; j < Star2[i].transform.childCount; j++)
            {
                if (Star2[i].transform.GetChild(j).gameObject.activeSelf)
                {
                    activeStarCount++;
                }
            }
        }
        int halfActiveStarCount = activeStarCount / 2;

        // TextMeshProUGUI 배열에 반으로 나눈 값을 설정
        for (int i = 0; i < StartCount.Length; i++)
        {
            StartCount[i].text = halfActiveStarCount.ToString();
        }
    }


}
