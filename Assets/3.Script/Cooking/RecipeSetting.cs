using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSetting : MonoBehaviour
{
    // Dictionary (요리 / 레시피)
    public Dictionary<int, List<int>> _recipePrep_D = new Dictionary<int, List<int>>();
    public Dictionary<int, List<int>> _recipeCook_D = new Dictionary<int, List<int>>();

    public void SetDefaultRecipe()
    {
        MashMellowRecipe();
        BeefStewRecipe();
        SkewersFlatterRecipe();
        SteakRecipe();
        SalmonSteakRecipe();
    }

    private void MashMellowRecipe()
    {
        // 마쉬멜로우 구이
        List<int> perptemp = new List<int> { 20001 };
        List<int> cooktemp = new List<int> { 21 };
        _recipePrep_D.Add((int)Cooking_Type.Marshmallow, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Marshmallow, cooktemp);
    }

    private void BeefStewRecipe()
    {
        // 비프스튜
        List<int> perptemp = new List<int> { 11110, 41000, 51000 };
        List<int> cooktemp = new List<int> { 11, 41, 51 };
        _recipePrep_D.Add((int)Cooking_Type.Beef_Stew, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Beef_Stew, cooktemp);
    }

    private void SkewersFlatterRecipe()
    {
        // 꼬치플레터
        List<int> perptemp = new List<int> { 11111, 61001, 81001 };
        List<int> cooktemp = new List<int> { 11, 61, 81 };
        _recipePrep_D.Add((int)Cooking_Type.Skewers_Flatter, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Skewers_Flatter, cooktemp);
    }

    private void SteakRecipe()
    {
        // 스테이크
        List<int> perptemp = new List<int> { 10110, 81000 };
        List<int> cooktemp = new List<int> { 11, 81 };
        _recipePrep_D.Add((int)Cooking_Type.Beef_Steak, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Beef_Steak, cooktemp);
    }

    private void SalmonSteakRecipe()
    {
        // 연어구이
        List<int> perptemp = new List<int> { 31110, 71000 };
        List<int> cooktemp = new List<int> { 31, 71 };
        _recipePrep_D.Add((int)Cooking_Type.Salmon_Steak, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Salmon_Steak, cooktemp);
    }



}
