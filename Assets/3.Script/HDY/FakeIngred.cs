using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Food_Type
{
    Beef = 0,
    Fish,
    Lamb,
    Chicken,
    Sausage,
    Mashmellow,
    Salmon,
    Shrimp,
    Lobster,
    Tomato,
    Potato = 10,
    Carrot,
    Onion,
    Lemon,
    Cabbage,
    Corn,
    Broccoli,
    paprika,
    Garlic,
    GreenOnion,
    Asparagus = 20,
    White_Mushroom,
}

public class FakeIngred : MonoBehaviour
{
    [SerializeField] private Food_Type food_type;
    public int hp = 5;

}
