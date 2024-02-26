using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle_meat : MonoBehaviour
{
    public GameObject Meat_Up;
    public GameObject Meat_Down;
    public GameObject Meat_steak;
    private Cooked_Ingredient meat_up_ing;
    private Cooked_Ingredient meat_down_ing;
    private Cooked_Ingredient middle_cook;
    private Ingredient middle_ingredient;
    public Cooked_Ingredient steak_cook;
    private void Start()
    {
        meat_up_ing = Meat_Up.GetComponent<Cooked_Ingredient>();
        meat_down_ing = Meat_Down.GetComponent<Cooked_Ingredient>();
        middle_cook = GetComponent<Cooked_Ingredient>();
        middle_ingredient = GetComponent<Ingredient>();
        steak_cook = steak_cook.GetComponent<Cooked_Ingredient>();
    }

    private void FixedUpdate()
    {
        if(meat_up_ing._cooked_State==Cooked_Ingredient.Cooked_State.Burned || meat_down_ing._cooked_State == Cooked_Ingredient.Cooked_State.Burned)
        {
            middle_cook.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Cook);//�������ͽ� ����
            middle_ingredient.Cook_ch_mat();//���׸��� ����
            steak_cook.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Burned);
            if (meat_up_ing._cooked_State == Cooked_Ingredient.Cooked_State.Burned && meat_down_ing._cooked_State == Cooked_Ingredient.Cooked_State.Burned)
            {
                middle_cook.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Burned);//�������ͽ� ����
                middle_ingredient.Cook_ch_mat();//���׸��� ����
            }
        }
        else if(meat_up_ing._cooked_State == Cooked_Ingredient.Cooked_State.Cook && meat_down_ing._cooked_State == Cooked_Ingredient.Cooked_State.Cook)
        {
            middle_cook.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Cook);//�������ͽ� ����
            middle_ingredient.Cook_ch_mat();//���׸��� ����
            steak_cook.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Cook);
        }
    }




}
