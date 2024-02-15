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
    Beef = 1,
    Mashmellow,
    Salmon,
    Potato,
    Carrot,
    Onion,
    Asparagus,
    Mushroom,
}

public enum cut_state
{
    Notcut=0,
    Cut,
}


public class Ingredient : MonoBehaviour
{
    public Ingredient_Type ingredient_type;
    public Cooked_Ingredient cooked_ingred;
    public Seasoning_Ingredient seasoning_ingred;
    public Skewer_Ingredient skewer_ingred;

    public Material[] materials;
    public MeshRenderer mat;

    private void Start()
    {
        TryGetComponent<Seasoning_Ingredient>(out seasoning_ingred);
        TryGetComponent<Cooked_Ingredient>(out cooked_ingred);
        TryGetComponent<Skewer_Ingredient>(out skewer_ingred);
        mat = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        cooked_ingred.OnUpdate();
        skewer_ingred.OnUpdate();

    }

    public void Cook_ch_mat()// 쿡스테이터스에 따라 머테리얼 값을 변경한다
    {
        mat.material = materials[(int)cooked_ingred.cooked_state];
    }




}
