using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiling_sliceObj : MonoBehaviour
{
    //private new MeshRenderer renderer;
    //public Material black_mat;

    //public Cooked_Ingredient cooked_state;
    //private List<Food_Type> foodtype = new List<Food_Type>(); //Ingredient_Type으로 바꿀 것

    //public int add_hp = 5;

    //private void Start()
    //{
    //    cooked_state = GetComponent<Cooked_Ingredient>();
    //    cooked_state.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Raw);
    //}

    //private void Update()
    //{
    //    Boiling_stat();
    //    InputFood();
    //}

    //public void InputFood()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        //AddFoodToList(Food_Type.Carrot);
    //        add_hp++;
    //    }

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        //AddFoodToList(Food_Type.Potato);
    //        add_hp++;
    //    }

    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        //AddFoodToList(Food_Type.Beef);
    //        add_hp++;
    //    }
    //}

    //private void AddFoodToList(Food_Type food)
    //{
    //    if (!foodtype.Contains(food))
    //    {
    //        foodtype.Add(food);
    //        Debug.Log(food + "를 더했다");
    //    }
        
    //}

    //private void Boiling_stat()
    //{
    //    switch (cooked_state.cooked_state)
    //    {
    //        case Cooked_Ingredient.Cooked_State.Raw:

    //            break;
    //        case Cooked_Ingredient.Cooked_State.Roasted:

    //            break;
    //        case Cooked_Ingredient.Cooked_State.Boiled:

    //            break;
    //        case Cooked_Ingredient.Cooked_State.Burnt:

    //            break;

    //        default:
    //            break;
    //    }
    //}


}
