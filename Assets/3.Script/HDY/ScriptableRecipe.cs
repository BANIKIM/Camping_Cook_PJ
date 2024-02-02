using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableRecipe : ScriptableObject
{
    public Cuisine cuisine;
    public int Level;
    public Sprite menuIcon;
    
    public enum Cuisine
    {
        Marshmallow, GrilledSalmon, BeefSteak, StickPlatter, BeefStew
    }

    public enum Ingredient
    {
        marshmallow = 0,
        beef,
        salmon,
        asparagus,
        potato,
        carrot,
        onion,
        mushroom
    }

    public enum CookedType
    {
        cut_0 = 0, cut_1, cut_2, cut_3,
        seasoning_s = 10, seasoning_p = 11,
        stick = 20,
        toast_1 = 30, toast_2, toast_3,
        toast_all = 40,
        boil_0 = 50, boil_1, boil_2
    }
}
