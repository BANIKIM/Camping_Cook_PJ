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
            midIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//스테이터스 변경
            ingredient.Cook_ch_mat();//머테리얼 변경
            cookedIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);
            if (upIngredient.cookedState == CookedIngredient.Cooked_State.Burned && lowIngredient.cookedState == CookedIngredient.Cooked_State.Burned)
            {
                midIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Burned);//스테이터스 변경
                ingredient.Cook_ch_mat();//머테리얼 변경
            }
        }
        else if (upIngredient.cookedState == CookedIngredient.Cooked_State.Cook && lowIngredient.cookedState == CookedIngredient.Cooked_State.Cook)
        {
            midIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);//스테이터스 변경
            ingredient.Cook_ch_mat();//머테리얼 변경
            cookedIngredient.Change_Cooked_State(CookedIngredient.Cooked_State.Cook);
        }
    }
}
