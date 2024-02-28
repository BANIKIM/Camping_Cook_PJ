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
        // ������ ���� Ȱ��ȭ�� ��Ÿ�� ���� ��� (�ִ� 3������)
        for (int i = 0; i < idx; i++)
        {
            Star[Num].transform.GetChild(i).gameObject.SetActive(true);
            Star2[Num].transform.GetChild(i).gameObject.SetActive(true);
        }

    }


    private void UpdateActiveStarCount()
    {
        // Ȱ��ȭ�� ���� ������ �ʱ�ȭ
        activeStarCount = 0;

        // �� �丮�� ���� Ȱ��ȭ�� ���� ������ ����Ͽ� �ջ�
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

        // TextMeshProUGUI �迭�� ������ ���� ���� ����
        for (int i = 0; i < StartCount.Length; i++)
        {
            StartCount[i].text = halfActiveStarCount.ToString();
        }
    }


}
