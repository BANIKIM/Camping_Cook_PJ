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
            HP = 5;//�ٷ� Ÿ�°� ����
            HP += 5;
            for (int i = 0; i < Foods.Length; i++)
            {
                Foods[i].SetActive(true);
            }
            
            Destroy(other.gameObject);
        }
    }

    private void Onsmoke()
    {
        if (HP < 5)
        {
            smoke.SetActive(true);
            if(Foods[0].activeSelf)
            {
                cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Cook);//�������ͽ� ����
                ingredient.Cook_ch_mat();//���׸��� ����
                ingredient._crossMat = ingredient._mesh.material;
            }         
        }
        else
        {
            smoke.SetActive(false);
        }
    }

    private void isTan()
    {
        if(HP<0 && Foods[0].activeSelf)
        {
            cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burned);//�������ͽ� ����
            ingredient.Cook_ch_mat();//���׸��� ����
            ingredient._crossMat = ingredient._mesh.material;

        }
    }
}
