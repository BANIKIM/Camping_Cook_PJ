using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Meat_Type
{
    Beef = 0,   //�Ұ��
    Tomahawk,   //�丶ȣũ
    Lamb,       //����
    Chicken,    //�߰��
    Sausage,    //�򽼺� �Ķ�ũ
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
