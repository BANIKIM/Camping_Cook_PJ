using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{

    private Cooked_Ingredient cooked;
    private Ingredient ingredient;
    [SerializeField] private float CookTime = 0;
    public float limit_CookTime;
    public Tool_heat tool_heat;
    public bool meat;

    private void Start()
    {
        cooked = GetComponent<Cooked_Ingredient>();
        ingredient = GetComponent<Ingredient>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CookTool"))
        {
            tool_heat = other.GetComponent<Tool_heat>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (tool_heat != null)
        {
            if (tool_heat.tool_heat)
            {
                CookTime += Time.deltaTime;
                if (CookTime > limit_CookTime)//������
                {
                    cooked.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Cook);//�������ͽ� ����
                    ingredient.Cook_ch_mat();//���׸��� ����
                    if (CookTime > limit_CookTime + 10)//ź��
                    {
                        cooked.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Burned);//�������ͽ� ����
                        ingredient.Cook_ch_mat();//���׸��� ����
                    }
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CookTool"))
        {

            tool_heat = null;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CookTool"))
        {
            tool_heat = collision.gameObject.GetComponent<Tool_heat>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (tool_heat != null)
        {
            if (tool_heat.tool_heat)
            {
                if (!meat)
                {
                    CookTime += Time.deltaTime;
                    if (CookTime > limit_CookTime)//������
                    {
                        Debug.Log("�ʹ���");
                        cooked.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Cook);//�������ͽ� ����
                        ingredient.Cook_ch_mat();//���׸��� ����
                        if (CookTime > limit_CookTime + 10)//ź��
                        {
                            cooked.Change_Cooked_State(Cooked_Ingredient.Cooked_State.Burned);//�������ͽ� ����
                            ingredient.Cook_ch_mat();//���׸��� ����
                        }
                    }
                }
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CookTool"))
        {
            tool_heat = null;
        }
    }
}