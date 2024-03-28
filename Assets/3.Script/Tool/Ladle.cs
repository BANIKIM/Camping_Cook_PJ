using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladle : MonoBehaviour
{
    public GameObject Liquidin;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Liquid"))
        {
            Liquidin.SetActive(true);
            Liquidin.gameObject.GetComponent<MeshRenderer>().material = other.GetComponent<Ingredient>().crossMat;
        }
    }

    public void Liquid_Move(Collider other)
    {
        Liquidin.gameObject.GetComponent<CookedIngredient>().Change_Cooked_State(other.GetComponent<CookedIngredient>().cookedState);//스테이터스를 바꾼다
        Liquidin.gameObject.GetComponent<SeasoningIngredient>().salt_s = other.gameObject.GetComponent<SeasoningIngredient>().salt_s; // 소금도 주고
        Liquidin.gameObject.GetComponent<SeasoningIngredient>().pepper_s = other.gameObject.GetComponent<SeasoningIngredient>().pepper_s; //페퍼도 준다
    }
}
