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
            Liquidin.gameObject.GetComponent<MeshRenderer>().material = other.GetComponent<Ingredient>()._crossMat;
        }
    }

    public void Liquid_Move(Collider other)
    {
        Liquidin.gameObject.GetComponent<Cooked_Ingredient>().Change_Cooked_State(other.GetComponent<Cooked_Ingredient>()._cooked_State);//스테이터스를 바꾼다
        Liquidin.gameObject.GetComponent<Seasoning_Ingredient>().salt_s = other.gameObject.GetComponent<Seasoning_Ingredient>().salt_s; // 소금도 주고
        Liquidin.gameObject.GetComponent<Seasoning_Ingredient>().pepper_s = other.gameObject.GetComponent<Seasoning_Ingredient>().pepper_s; //페퍼도 준다
    }
}
