using UnityEngine;

public class MiddleMeat : MonoBehaviour
{
    public GameObject meatUp;
    public GameObject meatLow;
    public GameObject meatMiddle;

    private CookedIngredient upIngredient;
    private CookedIngredient lowIngredient;
    private CookedIngredient midIngredient;

    private Ingredient ingredient;
    public CookedIngredient cookedIngredient;

    private void Start()
    {
        upIngredient = meatUp.GetComponent<CookedIngredient>();
        lowIngredient = meatLow.GetComponent<CookedIngredient>();
        midIngredient = GetComponent<CookedIngredient>();
        ingredient = GetComponent<Ingredient>();
        cookedIngredient = cookedIngredient.GetComponent<CookedIngredient>();
    }

    private void FixedUpdate()
    {
        if (upIngredient.cookedState == CookedIngredient.Cooked_State.Burned || lowIngredient.cookedState == CookedIngredient.Cooked_State.Burned)
        {
            midIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//�������ͽ� ����
            ingredient.Cook_ch_mat();//���׸��� ����
            cookedIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);
            if (upIngredient.cookedState == CookedIngredient.Cooked_State.Burned && lowIngredient.cookedState == CookedIngredient.Cooked_State.Burned)
            {
                midIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);//�������ͽ� ����
                ingredient.Cook_ch_mat();//���׸��� ����
            }
        }
        else if (upIngredient.cookedState == CookedIngredient.Cooked_State.Cook && lowIngredient.cookedState == CookedIngredient.Cooked_State.Cook)
        {
            midIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//�������ͽ� ����
            ingredient.Cook_ch_mat();//���׸��� ����
            cookedIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);
        }
    }
}
