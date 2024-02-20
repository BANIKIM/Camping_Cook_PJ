using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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

[RequireComponent(typeof(Cooked_Ingredient))]
[RequireComponent(typeof(Seasoning_Ingredient))]
[RequireComponent(typeof(Skewer_Ingredient))]

public class Ingredient : MonoBehaviour
{
    public Ingredient_Type ingredient_type;
    public Cooked_Ingredient cooked_ingred;
    public Seasoning_Ingredient seasoning_ingred;
    public Skewer_Ingredient skewer_ingred;

    public bool isSlice = false;

    public int _sliceCount = 0;

    public Material _crossMat;
    public Material[] materials;
    public MeshRenderer mat;

    private void Start()
    {
        TryGetComponent(out seasoning_ingred);
        TryGetComponent(out cooked_ingred);
        TryGetComponent(out skewer_ingred);
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

    public int CheckCookIdx()
    {
        var temp = isSlice ? 1 : 0;
        var ingred_type = ((int)ingredient_type * 100000) + (temp * 10000) +
            ((int)seasoning_ingred.salt_s * 1000) + ((int)seasoning_ingred.pepper_s * 100) +
            ((int)skewer_ingred.skewer_state * 10) + ((int)cooked_ingred.cooked_state);

        return ingred_type;
    }
}
