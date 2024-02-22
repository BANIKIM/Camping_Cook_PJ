using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBoil : MonoBehaviour
{
    public GameObject Cook_Tool_pot;
    public Tool_heat heat;
    public GameObject smoke;

    public float HP = 10;
    public Ingredient[] Foods;
    private Cooked_Ingredient cooked;

    private Ingredient ingredient;
    private int number = 0;
    public List<int> _ingred_Type_L = new List<int>();

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
            Onsmoke();//스모크 이펙트 키기
            isTan();//시간지나면 탐
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        List<int> recipe = CookManager.instance.Recipe_C(UiManager.instance.Num);

        if (other.gameObject.layer == 6) //조건에서 받아야 하는 Ingredient_Type 타입을 받아야 함 이거 0을 어떻게 받냐?
        {
            HP += 5;
            Ingredient_Type type = other.GetComponent<Ingredient>()._ingredient_Type;

            Destroy(other.gameObject);
   
            for (int i = 0; i < Foods.Length; i++)
            {
                if (!Foods[i].enabled && !Foods[i]._ingredient_Type.Equals(type))
                {
                    _ingred_Type_L.Add((int)type);
                    Foods[i].transform.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void Onsmoke()
    {
        if (HP < 5)
        {
            smoke.SetActive(true);
            if (Foods[0].transform.gameObject.activeSelf)
            {
                cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Cook);//스테이터스 변경
                ingredient.Cook_ch_mat();//머테리얼 변경
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
        if (HP < 0 && Foods[0].transform.gameObject.activeSelf)
        {
            cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burned);//스테이터스 변경
            ingredient.Cook_ch_mat();//머테리얼 변경
            ingredient._crossMat = ingredient._mesh.material;

        }
    }
}
