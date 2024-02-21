using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Cooking_ch))]//������Ʈ �����߰�

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









    //�̸�
    public int isType(Ingredient ingred)
    {
        return (int)ingred._ingredient_Type * 100000;
    }

    //�ڸ���
    public int isCut(Ingredient ingred)
    {
        if (ingred.isSlice)
        {
            return 10000;
        }
        return 0;
    }
    //�ұ� ����
    public int issalt(Ingredient ingred) // �ұ�üũ
    { 
        if(ingred._seasoningIngred.salt_s.Equals(Seasoning_Ingredient.Salt_S.Salted))
        {
            return 1000;
        }
        return 0;      
    }
    public int ispepper(Ingredient ingred) //����üũ
    {
        if (ingred._seasoningIngred.pepper_s.Equals(Seasoning_Ingredient.Pepper_S.Peppered))
        {
            //����
            return 100;
        }
        return 0;
    }
    //�ȱ�
    public int isSkewer(Ingredient ingred)
    {
        if(ingred._skewerIngred.skewer_state.Equals(Skewer_State.Inserted))
        {
            return 10;
        }
        return 0;
    }
    //����
    public int isCooked(Ingredient ingred)
    {
        if(ingred._cookedIngred._cooked_State == Cooked_Ingredient.Cooked_State.Cook)
        {
            return 1;
        }
        return 0;
    }
}
