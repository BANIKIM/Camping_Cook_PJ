using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private CookingTimer cookingTimer;

    public CookingTimer CookingTimer
    {
        get
        {
            return cookingTimer;
        }
    }
    [SerializeField]
    private RecipesUI recipesUI;

    public RecipesUI RecipesUI
    {
        get
        {
            return recipesUI;
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
    }
    public void OnStar()
    {
        // ������ ���� Ȱ��ȭ�� ��Ÿ�� ���� ��� (�ִ� 3������)
        int starCount = Mathf.Min(expUI.level, 3);

        if (Num == 1) //������ο� 
        {            
                // ��Ÿ �迭�� ��Ÿ2 �迭�� �ڽ� ������Ʈ Ȱ��ȭ
                for (int i = 0; i < starCount; i++)
                {
                    Star[0].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[0].transform.GetChild(i).gameObject.SetActive(true);
                }
                  
        }
        else if (Num == 2) //���� ��Ʃ 
        {
          
            for (int i = 0; i < starCount; i++)
            {
                Star[1].transform.GetChild(i).gameObject.SetActive(true);
                Star2[1].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (Num == 3) //��ġ �÷��� 
        {
     

            for (int i = 0; i < starCount; i++)
            {
                Star[2].transform.GetChild(i).gameObject.SetActive(true);
                Star2[2].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if(Num == 4) //������ũ 
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


}
