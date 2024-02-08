using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle_meat : MonoBehaviour
{
    public GameObject Meat_Up;
    public GameObject Meat_Down;
    private new MeshRenderer renderer;
    public Material Cooked_mat;
    public Material Burnt_mat;

    public Cooked_Ingredient meat_up_State;
    public Cooked_Ingredient meat_down_State;



private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
         meat_up_State = Meat_Up.GetComponent<Cooked_Ingredient>();
         meat_down_State = Meat_Down.GetComponent<Cooked_Ingredient>();
    }

    void Update()
    {
        if(meat_up_State.cooked_state == Cooked_Ingredient.Cooked_State.Roasted &&
            meat_down_State.cooked_state == Cooked_Ingredient.Cooked_State.Roasted)
        {
            Material[] materials = renderer.materials;
            materials[0] = Cooked_mat; // 원하는 매터리얼로 변경
            renderer.materials = materials; // 변경된 매터리얼 적용
        }
        else if(meat_up_State.cooked_state == Cooked_Ingredient.Cooked_State.Burnt ||
            meat_down_State.cooked_state == Cooked_Ingredient.Cooked_State.Burnt)
        {
            Material[] materials = renderer.materials;
            materials[0] = Cooked_mat; // 원하는 매터리얼로 변경
            renderer.materials = materials; // 변경된 매터리얼 적용
            if(meat_up_State.cooked_state == Cooked_Ingredient.Cooked_State.Burnt &&
            meat_down_State.cooked_state == Cooked_Ingredient.Cooked_State.Burnt)
            {
                materials = renderer.materials;
                materials[0] = Burnt_mat; // 원하는 매터리얼로 변경
                renderer.materials = materials; // 변경된 매터리얼 적용
            }
        }
        
    }
}
