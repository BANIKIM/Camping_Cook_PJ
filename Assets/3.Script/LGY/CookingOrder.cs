using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CookingOrder : MonoBehaviour
{
    public enum Tool_Idx
    {
        Pepper = 0,
        CampFire,
        Grill,
        Knife,
        Plate,
        Pot,
        Salt,
        Scoop,
        Skewer,
        Tongs,
    }

    public Image[] _line1;
    public Image[] _line2;
    public Image[] _line3;
    public Image[] _line4;
    public Image[] _line5;

    public Sprite[] _ingredientImgs;
    public Sprite[] _toolmgs;


    public void OrderSetting(List<int> toolList, List<int> ingredList)
    {
        _line1[0].sprite = _toolmgs[(int)Tool_Idx.Skewer];
        _line1[1].sprite = _ingredientImgs[(int)Ingredient_Type.Mashmellow];
    }


}
