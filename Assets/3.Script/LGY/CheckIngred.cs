using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIngred : MonoBehaviour
{
    public void CheckIngredType(Ingredient ingred)
    {
        var ingred_type = ((int)ingred.ingredient_type * 100000)
            + ((int)ingred.seasoning_ingred.salt_s * 1000) + ((int)ingred.seasoning_ingred.pepper_s * 100) +
            ((int)ingred.skewer_ingred.skewer_state * 10) + (int)ingred.cooked_ingred.cooked_state;

        switch (ingred_type)
        {
            case 0:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;





            default:
                break;
        }


    }

}
