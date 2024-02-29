using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance = null;


    public GameObject[] Star2;
    public TextMeshProUGUI StartCount;



    public GameObject updateObject2;

    public GameObject dishSpawnPoint;

    public int activeStarCount = 0;
    public bool isCookingStarted = false;

    public int _cookIdx = 0;

    private void Awake()
    {
        instance = this;
        TryGetComponent(out _uiExperience);
        TryGetComponent(out update_CookUI2);
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


    public UIExperience _uiExperience;

    private void Update()
    {
        UpdateActiveStarCount();
    }
    public void OnStar(int idx)
    {
        // 레벨에 따라 활성화할 스타의 개수 계산 (최대 3개까지)
        for (int i = 0; i < idx; i++)
        {

            Star2[_cookIdx].transform.GetChild(i).gameObject.SetActive(true);
        }

    }


    private void UpdateActiveStarCount()
    {
        // 활성화된 별의 갯수를 초기화
        activeStarCount = 0;



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
        StartCount.text = halfActiveStarCount.ToString();
    }


}
