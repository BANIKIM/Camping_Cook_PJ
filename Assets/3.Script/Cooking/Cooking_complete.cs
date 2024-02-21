using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_complete : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer ==6)
        {
            Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();
        }
    }
    //이름

    //자르기
    public int isCut(Ingredient ingred)
    {
        if(ingred.isSlice)
        {
            return 10000;
        }
        return 0;
    }

    //소금 후추
    public int isSeasoning(Ingredient ingred)
    {

        if(ingred._seasoningIngred.pepper_s.Equals(Seasoning_Ingredient.Pepper_S.Peppered))
        {
            //소금 후추
            return 1000;
        }
        if(ingred._seasoningIngred.salt_s.Equals(Seasoning_Ingredient.Salt_S.Salted))
        {
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
