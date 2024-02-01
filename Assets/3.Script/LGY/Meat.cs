using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Meat_Type
{
    Beef = 0,   //¼Ò°í±â
    Tomahawk,   //Åä¸¶È£Å©
    Lamb,       //¾ç°í±â
    Chicken,    //´ß°í±â
    Sausage,    //Àò½¼ºô ÈÄ¶ûÅ©
}

public class Meat : Ingredient
{
    public Meat_Type meat_type;

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
