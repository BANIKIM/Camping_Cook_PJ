using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeaFood_Type
{
    Salmon = 0,  //연어
    Shrimp,      //새우
    Lobster,     //랍스터
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
