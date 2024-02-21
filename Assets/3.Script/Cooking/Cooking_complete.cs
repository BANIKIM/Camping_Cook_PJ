using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_complete : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer ==6)
        {

        }
    }
    //이름

    //자르기
    public int isCut(Collision collision)
    {
        if(collision.gameObject.GetComponent<Ingredient>().isSlice)
        {
            return 10000;
        }
        return 0;
    }

    //소금 후추
    public int isSeasoning(Collision collision)
    {
        if(true)
        {
            //소금 후추
            return 1100;
        }
        return 0;
        
    }
    //꽂기
    public int isSkewer(Collision collision)
    {
        if(true)
        {
            return 10;
        }
        return 0;
    }

    //익힘
    public int isCooked(Collision collision)
    {
        if(collision.gameObject.GetComponent<Cooked_Ingredient>().cooked_state == Cooked_Ingredient.Cooked_State.Cook)
        {
            return 1;
        }
        return 0;
    }
}
