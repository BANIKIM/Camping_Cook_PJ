using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CookType
{
    ������ο� = 0,
    ������Ʃ = 1,
    ��ġ�÷��� = 2,
    ������ũ = 3,
    �������ũ = 4
}
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
    private void Update()
    {
        OnStar();
        UpdateActiveStarCount();
    }
    public void OnStar()
    {
        // ������ ���� Ȱ��ȭ�� ��Ÿ�� ���� ��� (�ִ� 3������)
        int starCount = Mathf.Min(expUI.level, 3);

        if (Num == 0) //������ο� 
        {            
                // ��Ÿ �迭�� ��Ÿ2 �迭�� �ڽ� ������Ʈ Ȱ��ȭ
                for (int i = 0; i < starCount; i++)
                {
                    Star[0].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[0].transform.GetChild(i).gameObject.SetActive(true);
                }
                  
        }
        else if (Num == 1) //���� ��Ʃ 
        {
          
            for (int i = 0; i < starCount; i++)
            {
                Star[1].transform.GetChild(i).gameObject.SetActive(true);
                Star2[1].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (Num == 2) //��ġ �÷��� 
        {
     

            for (int i = 0; i < starCount; i++)
            {
                Star[2].transform.GetChild(i).gameObject.SetActive(true);
                Star2[2].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if(Num == 3) //������ũ 
        {
 
            for (int i = 0; i < starCount; i++)
            {
                Star[3].transform.GetChild(i).gameObject.SetActive(true);
                Star2[3].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if(Num == 4) // ���� ������ũ
        {
           

            for (int i = 0; i < starCount; i++)
            {
                Star[4].transform.GetChild(i).gameObject.SetActive(true);
                Star2[4].transform.GetChild(i).gameObject.SetActive(true);
            }
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
