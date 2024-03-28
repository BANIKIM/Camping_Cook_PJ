using UnityEngine;

public class Cooking : MonoBehaviour
{
    private CookedIngredient cookedIngredinet;
    private Ingredient ingredient;
    public Tool_heat toolHeat;

    [SerializeField] private float cookTime = 0;
    public float limitCookTime;
    public bool isMeat;

    private void Start()
    {
        cookedIngredinet = GetComponent<CookedIngredient>();
        ingredient = GetComponent<Ingredient>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CookTool"))
        {
            toolHeat = other.GetComponent<Tool_heat>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toolHeat != null)
        {
            if (toolHeat.isToolHeat)
            {
                cookTime += Time.deltaTime;
                if (cookTime > limitCookTime)//������
                {
                    cookedIngredinet.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//�������ͽ� ����
                    ingredient.Cook_ch_mat();//���׸��� ����
                    if (cookTime > limitCookTime + 10)//ź��
                    {
                        cookedIngredinet.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);//�������ͽ� ����
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
            toolHeat = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CookTool"))
        {
            toolHeat = collision.gameObject.GetComponent<Tool_heat>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (toolHeat != null)
        {
            if (toolHeat.isToolHeat && !isMeat)
            {
                cookTime += Time.deltaTime;
                if (cookTime > limitCookTime)//������
                {
                    cookedIngredinet.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//�������ͽ� ����
                    ingredient.Cook_ch_mat();//���׸��� ����
                    if (cookTime > limitCookTime + 10)//ź��
                    {
                        cookedIngredinet.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);//�������ͽ� ����
                        ingredient.Cook_ch_mat();//���׸��� ����
                    }
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CookTool"))
        {
            toolHeat = null;
        }
    }
}
