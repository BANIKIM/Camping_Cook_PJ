using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrilledSystem : MonoBehaviour
{
    // 레시피 때 점수 추가
    // 사운드 추가

    private new MeshRenderer renderer;
    public Material Cooked_mat;
    public Material Burnt_mat;
    public float time;

    public Cooked_Ingredient meat_State;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        meat_State = GetComponent<Cooked_Ingredient>();
    }

    private void OnTriggerStay(Collider other)
    {

        time += Time.deltaTime;

        if (time >= 5)
        {
            Material[] materials = renderer.materials;
            materials[0] = Cooked_mat; // 원하는 매터리얼로 변경
            renderer.materials = materials; // 변경된 매터리얼 적용
            meat_State.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Roasted); //구운거
        }
        if (time >= 15)
        {
            Material[] materials = renderer.materials;
            materials[0] = Burnt_mat;
            renderer.materials = materials;
            meat_State.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burnt);//탄거

        }

    }
}




