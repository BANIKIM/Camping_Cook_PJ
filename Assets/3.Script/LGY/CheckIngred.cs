using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIngred : MonoBehaviour
{
    public void CheckIngredType(List<int> dish, Ingredient ingred)
    {
        var ingred_type = ((int)ingred.ingredient_type * 100000) +
            ((int)ingred.seasoning_ingred.salt_s * 1000) + ((int)ingred.seasoning_ingred.pepper_s * 100) +
            ((int)ingred.skewer_ingred.skewer_state * 10) + (int)ingred.cooked_ingred.cooked_state;

        dish.Add(ingred_type);


    }

}
