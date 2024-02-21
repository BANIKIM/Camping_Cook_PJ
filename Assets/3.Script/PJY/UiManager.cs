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

    public int activeStarCount = 0;

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
    private ExpUI expUI;
    
    public ExpUI ExpUI
    {
        get
        {
            return expUI;
        }
    }
    [SerializeField]
    private ExpUI expUI2;
    public ExpUI ExpUI2
    {
        get
        {
            return expUI2;
        }
    }
    private void Update()
    {
        UpdateActiveStarCount();
    }
    public void OnStar(int idx)
    {
        // ������ ���� Ȱ��ȭ�� ��Ÿ�� ���� ��� (�ִ� 3������)
        switch (Num)
        {
            case 0:  
                // ��Ÿ �迭�� ��Ÿ2 �迭�� �ڽ� ������Ʈ Ȱ��ȭ
                for (int i = 0; i < idx; i++)
                {
                    Star[0].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[0].transform.GetChild(i).gameObject.SetActive(true);
                }
                break;
            case 1:
                for (int i = 0; i < idx; i++)
                {
                    Star[1].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[1].transform.GetChild(i).gameObject.SetActive(true);
                }
                break;
            case 2:
                for (int i = 0; i < idx; i++)
                {
                    Star[2].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[2].transform.GetChild(i).gameObject.SetActive(true);
                }
                break;
            case 3:
                for (int i = 0; i < idx; i++)
                {
                    Star[3].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[3].transform.GetChild(i).gameObject.SetActive(true);
                }
                break;
            case 4:
                for (int i = 0; i < idx; i++)
                {
                    Star[4].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[4].transform.GetChild(i).gameObject.SetActive(true);
                }
                break;

            default:
                break;
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
