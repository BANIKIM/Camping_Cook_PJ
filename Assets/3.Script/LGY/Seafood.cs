using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeaFood_Type
{
    Salmon = 0,  //����
    Shrimp,      //����
    Lobster,     //������
}

public class SeaFood : Ingredient
{
    public SeaFood_Type seafood_type;

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
