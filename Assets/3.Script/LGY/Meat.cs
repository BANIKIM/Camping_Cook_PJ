using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeatType
{
    Meat = 0,
    Meat1,
    Meat2,
    Meat3,
    Meat4,
}

public class Meat : Food
{
    public MeatType meattype;

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }


}
