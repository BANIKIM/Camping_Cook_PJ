using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIngred : MonoBehaviour
{
    public GameObject A;

    public void Test()
    {
        A.TryGetComponent<Ingredient>(out Ingredient ingred);
    }

    public void CheckIngredType(Ingredient_Type ingred_T)
    {
        switch (ingred_T)
        {
            case Ingredient_Type.Beef:
                break;
            case Ingredient_Type.Mashmellow:
                break;
            case Ingredient_Type.Salmon:
                break;
            case Ingredient_Type.Potato:
                break;
            case Ingredient_Type.Carrot:
                break;
            case Ingredient_Type.Onion:
                break;
            case Ingredient_Type.Asparagus:
                break;
            case Ingredient_Type.Mushroom:
                break;
            default:
                break;
        }
    }

}
