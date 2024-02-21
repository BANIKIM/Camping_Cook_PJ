using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Cooking_ch))]//컴포넌트 강제추가

public class Cooking_complete : MonoBehaviour
{

    public Cooking_ch cooking_Ch;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer ==6)
        {
            Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();
            cooking_Ch.Cookscore += isType(ingred);
            cooking_Ch.Cookscore += isCut(ingred);
            cooking_Ch.Cookscore += issalt(ingred);
            cooking_Ch.Cookscore += ispepper(ingred);
            cooking_Ch.Cookscore += isSkewer(ingred);
            cooking_Ch.Cookscore += isCooked(ingred);
        }
    }









    //이름
    public int isType(Ingredient ingred)
    {
        return (int)ingred._ingredient_Type * 100000;
    }

    //자르기
    public int isCut(Ingredient ingred)
    {
        if (ingred.isSlice)
        {
            return 10000;
        }
        return 0;
    }
    //소금 후추
    public int issalt(Ingredient ingred) // 소금체크
    { 
        if(ingred._seasoningIngred.salt_s.Equals(Seasoning_Ingredient.Salt_S.Salted))
        {
            return 1000;
        }
        return 0;      
    }
    public int ispepper(Ingredient ingred) //후추체크
    {
        if (ingred._seasoningIngred.pepper_s.Equals(Seasoning_Ingredient.Pepper_S.Peppered))
        {
            //후추
            return 100;
        }
        return 0;
    }
    //꽂기
    public int isSkewer(Ingredient ingred)
    {
        if(ingred._skewerIngred.skewer_state.Equals(Skewer_State.Inserted))
        {
            return 10;
        }
        return 0;
    }
    //익힘
    public int isCooked(Ingredient ingred)
    {
        if(ingred._cookedIngred._cooked_State == Cooked_Ingredient.Cooked_State.Cook)
        {
            return 1;
        }
        return 0;
    }
}
