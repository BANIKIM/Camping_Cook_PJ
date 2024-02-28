using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public List<int> _prep_List = new List<int>();
    public List<int> _cook_List = new List<int>();
    public GameObject[] Cooks;
    public bool onech = false;

    [SerializeField]
    private GameObject uI_DB_ParsingObj;

    [SerializeField]
    private UI_DB_Parsing uI_DB_Parsing;


    private void Start()
    {
        uI_DB_ParsingObj = GameObject.FindGameObjectWithTag("UIManager");
        uI_DB_Parsing = uI_DB_ParsingObj.GetComponent<UI_DB_Parsing>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();

            if (!_prep_List.Contains(ingred.CheckPrepIdx())) _prep_List.Add(ingred.CheckPrepIdx());
            if (!_cook_List.Contains(ingred.CheckCookIdx())) _cook_List.Add(ingred.CheckCookIdx());



            Cooks[UiManager.instance.Num].SetActive(true);
            //Destroy(other.gameObject);
            //값을초기화 해줘야 한다...
            ingred._ingredient_Type = 0; //타입0으로만들고
            ingred._sliceCount = 0; //슬라이스 0으로 만들고
            other.GetComponent<Cooked_Ingredient>().Change_Cooked_State(Cooked_Ingredient.Cooked_State.Raw);//굽기초기화
            other.GetComponent<Seasoning_Ingredient>().salt_s = 0; //소금초기화
            other.GetComponent<Seasoning_Ingredient>().pepper_s = 0;//후추초기화
            other.gameObject.SetActive(false);

        }

       /* if (other.gameObject.CompareTag("Liquid"))
        {
            other.GetComponent<LiquidBoil>().LiquidReset();
            other.gameObject.SetActive(false);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();

            if (!_prep_List.Contains(ingred.CheckPrepIdx())) _prep_List.Add(ingred.CheckPrepIdx());
            if (!_cook_List.Contains(ingred.CheckCookIdx())) _cook_List.Add(ingred.CheckCookIdx());



            Cooks[UiManager.instance.Num].SetActive(true);
            Destroy(collision.gameObject);

        }
    }

    public int ch_Reward()
    {
        Cooks[UiManager.instance.Num].SetActive(false);
        if (!onech)
        {
            ok(UiManager.instance.Num.ToString());
            onech = true;
        }
        return RewardManager.instance.RecipeCheck(_prep_List, _cook_List, UiManager.instance.Num);
    }


    public void ok(string i)
    {
        Debug.Log("같은거 여러번하냐?");
        uI_DB_Parsing.textType = UI_DB_Parsing.TextType.Cook;
        uI_DB_Parsing.number = i;
        uI_DB_Parsing.a = true;
    }


}
