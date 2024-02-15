using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{

    private Cooked_Ingredient cooked;
    private Ingredient ingredient;
    [SerializeField] private float CookTime = 0;
    public float limit_CookTime = 5;
    public Tool_heat tool_heat;
    private void Start()
    {
        cooked = GetComponent<Cooked_Ingredient>();
        ingredient = GetComponent<Ingredient>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CookTool"))
        {
            tool_heat = other.GetComponent<Tool_heat>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (tool_heat != null)
        {
            if (tool_heat.tool_heat)
            {
                CookTime += Time.deltaTime;
                if (CookTime > limit_CookTime)//구워짐
                {
                    cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Cook);//스테이터스 변경
                    ingredient.Cook_ch_mat();//머테리얼 변경
                    if (CookTime > limit_CookTime + 10)//탄거
                    {
                        cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burned);//스테이터스 변경
                        ingredient.Cook_ch_mat();//머테리얼 변경
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CookTool"))
        {
            tool_heat = null;
        }
    }

}
