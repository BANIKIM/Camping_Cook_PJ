using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public enum Ingredient_Type
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

public class Ingredient : MonoBehaviour
{
    [SerializeField] private Ingredient_Type ingredient_type;

    [HideInInspector] public Slice_Obj slice_obj;
    [HideInInspector] public Cooked_Ingredient cooked_ingred;
    [HideInInspector] public Seasoning_Ingredient seasoning_ingred;
    [HideInInspector] public Skewer_Ingredient skewer_ingred;

    private void Start()
    {
        TryGetComponent<Seasoning_Ingredient>(out seasoning_ingred);
        TryGetComponent<Slice_Obj>(out slice_obj);
        TryGetComponent<Cooked_Ingredient>(out cooked_ingred);
        TryGetComponent<Skewer_Ingredient>(out skewer_ingred);
    }

    private void FixedUpdate()
    {
        cooked_ingred.OnUpdate();
        skewer_ingred.OnUpdate();

        slice_obj.SliceObj();
    }





}
