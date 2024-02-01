using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Seafood_Type
{
    Salmon = 0,  //연어
    Shrimp,      //새우
    Lobster,     //랍스터
}

public class Seafood : Food
{
    public Seafood_Type seafood_type;

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
