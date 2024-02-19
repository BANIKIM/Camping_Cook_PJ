using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CookType
{
    마쉬멜로우 = 0,
    비프스튜 = 1,
    꼬치플래터 = 2,
    스테이크 = 3,
    연어스테이크 = 4
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
        // 레벨에 따라 활성화할 스타의 개수 계산 (최대 3개까지)
        int starCount = Mathf.Min(expUI.level, 3);

        if (Num == 1) //마쉬멜로우 
        {            
                // 스타 배열과 스타2 배열의 자식 오브젝트 활성화
                for (int i = 0; i < starCount; i++)
                {
                    Star[0].transform.GetChild(i).gameObject.SetActive(true);
                    Star2[0].transform.GetChild(i).gameObject.SetActive(true);
                }
                  
        }
        else if (Num == 2) //비프 스튜 
        {
          
            for (int i = 0; i < starCount; i++)
            {
                Star[1].transform.GetChild(i).gameObject.SetActive(true);
                Star2[1].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (Num == 3) //꼬치 플래터 
        {
     

            for (int i = 0; i < starCount; i++)
            {
                Star[2].transform.GetChild(i).gameObject.SetActive(true);
                Star2[2].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if(Num == 4) //스테이크 
        {
 
            for (int i = 0; i < starCount; i++)
            {
                Star[3].transform.GetChild(i).gameObject.SetActive(true);
                Star2[3].transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if(Num == 4) // 연어 스테이크
        {
           

            for (int i = 0; i < starCount; i++)
            {
                Star[4].transform.GetChild(i).gameObject.SetActive(true);
                Star2[4].transform.GetChild(i).gameObject.SetActive(true);
            }
        }


    }


}
