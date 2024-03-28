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
        Liquidin.gameObject.GetComponent<CookedIngredient>().Change_Cooked_State(other.GetComponent<CookedIngredient>().cookedState);//�������ͽ��� �ٲ۴�
        Liquidin.gameObject.GetComponent<SeasoningIngredient>().salt_s = other.gameObject.GetComponent<SeasoningIngredient>().salt_s; // �ұݵ� �ְ�
        Liquidin.gameObject.GetComponent<SeasoningIngredient>().pepper_s = other.gameObject.GetComponent<SeasoningIngredient>().pepper_s; //���۵� �ش�
    }
}
