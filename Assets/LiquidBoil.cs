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
            Onsmoke();//����ũ ����Ʈ Ű��
            isTan();//�ð������� Ž
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        List<int> recipe = CookManager.instance.Recipe_C(UiManager.instance.Num);

        if (other.gameObject.layer == 6) //���ǿ��� �޾ƾ� �ϴ� Ingredient_Type Ÿ���� �޾ƾ� �� �̰� 0�� ��� �޳�?
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
        if (HP < 0 && Foods[0].transform.gameObject.activeSelf)
        {
            cooked.Change_Skewer_State(Cooked_Ingredient.Cooked_State.Burned);//�������ͽ� ����
            ingredient.Cook_ch_mat();//���׸��� ����
            ingredient._crossMat = ingredient._mesh.material;

        }
    }
}
