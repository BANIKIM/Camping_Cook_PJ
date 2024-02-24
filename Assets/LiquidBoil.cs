using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBoil : MonoBehaviour
{
    public GameObject Cook_Tool_pot;
    public Tool_heat heat;
    public GameObject smoke;
    public float HP = 10;
    public GameObject[] Foods;
    private Cooked_Ingredient cooked;
    private Ingredient ingredient;
    private int number = 0;
    private bool a;

    public bool iscook = false;
    private bool isBurned = false;

    void Start()
    {
        heat = Cook_Tool_pot.gameObject.GetComponent<Tool_heat>();
        cooked = GetComponent<Cooked_Ingredient>();
        ingredient = GetComponent<Ingredient>();
    }

    private void FixedUpdate()
    {
        if (heat.tool_heat)
        {
            HP -= Time.deltaTime;
            Onsmoke();//����ũ ����Ʈ Ű��
            isTan();//�ð������� Ž
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            HP = 10;//�ٷ� Ÿ�°� ����
            HP += 5;
            Destroy(other.gameObject);

            for (int i = 0; i < Foods.Length; i++)
            {
                a = false;
                if (Foods[i].GetComponent<Ingredient>()._ingredient_Type == other.GetComponent<Ingredient>()._ingredient_Type)
                {
                    a = true;
                    break;
                }
            }
            if (!a)
            {
                Foods[number].GetComponent<Ingredient>()._ingredient_Type = other.GetComponent<Ingredient>()._ingredient_Type;
                Foods[number].GetComponent<Ingredient>()._sliceCount = 1;
                Foods[number].GetComponent<Seasoning_Ingredient>().salt_s = other.GetComponent<Seasoning_Ingredient>().salt_s;
                Foods[number].GetComponent<Seasoning_Ingredient>().pepper_s = other.GetComponent<Seasoning_Ingredient>().pepper_s;
                Foods[number].SetActive(true);
                number += 1;
            }
            if (number == 4) number = 0;


        }
    }
    private void Onsmoke()
    {
        if (HP < 5 && !iscook)
        {
            if (Foods[0].activeSelf)
            {
                for (int i = 0; i < Foods.Length; i++)
                {
                    Foods[i].GetComponent<Cooked_Ingredient>().Change_Skewer_State(Cooked_Ingredient.Cooked_State.Cook);
                }
                cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Cook);//�������ͽ� ����
                ingredient.Cook_ch_mat();//���׸��� ����
                ingredient._crossMat = ingredient._mesh.material;
                iscook = true;
            }
            
        }

    }

    private void isTan()
    {
        if (HP < 0 && Foods[0].activeSelf && !isBurned)
        {
            for (int i = 0; i < Foods.Length; i++)
            {
                Foods[i].GetComponent<Cooked_Ingredient>().Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burned);
            }
            cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burned);//�������ͽ� ����
            ingredient.Cook_ch_mat();//���׸��� ����
            ingredient._crossMat = ingredient._mesh.material;

            isBurned = true;
        }
    }

    public void LiquidReset()//���� ���׸��� �� �ʱ�� ������.
    {
        cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Raw);//�������ͽ� ����
        ingredient.Cook_ch_mat();//���׸��� ����
        ingredient._crossMat = ingredient._mesh.material;
    }
}
