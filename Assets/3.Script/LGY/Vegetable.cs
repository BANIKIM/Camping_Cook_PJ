using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Vegetable_Type
{
    Tomato = 0,
    Potato,
    Carrot,
    Onion,
    Lemon,
    Cabbage,
    Corn,
    Broccoli,
    paprika,
    Garlic,
    GreenOnion = 10,  // ´ëÆÄ
    Asparagus,
    White_Mushroom,
}

public class Vegetable : Ingredient
{
    public Vegetable_Type vegetable_type;

    public override void RoastOnEnter()
    {

    }

    public override void RoastOnUpdate()
    {

    }

    public override void RoastOnExit()
    {

    }

}
