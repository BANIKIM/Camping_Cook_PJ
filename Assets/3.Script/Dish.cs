using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public List<int> Cooking = new List<int>();
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
            Cooking.Add(ingred.CheckCookIdx());

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();

            if (!Cooking.Contains(ingred.CheckCookIdx())) Cooking.Add(ingred.CheckCookIdx());
            Cooks[UiManager.instance.Num].SetActive(true);
            Destroy(collision.gameObject);

        }
    }

    public int ch_Reward()
    {
        Debug.Log(UiManager.instance.Num);
        Cooks[UiManager.instance.Num].SetActive(false);
        if(!onech)
        {
            ok(UiManager.instance.Num.ToString());
            onech = true;
        }
        return RewardSystem.instance.RecipeCheck(Cooking, UiManager.instance.Num);
    }


    public void ok(string i)
    {
        Debug.Log("같은거 여러번하냐?");
        uI_DB_Parsing.textType = UI_DB_Parsing.TextType.Cook;
        uI_DB_Parsing.number = i;
        uI_DB_Parsing.a = true;
    }
}
