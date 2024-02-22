using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cooking_Type
{
    Mashmellow = 0,
    Beef_Stew,
    Skewers_Flatter,
    Steak,
    Grilled_Salmon,
}

public class RecipeSetting : MonoBehaviour
{
    // Dictionary (요리 / 레시피)
    public Dictionary<int, List<int>> _recipe_D = new Dictionary<int, List<int>>();

    public void SetDefaultRecipe()
    {
        MashMellow_R();
        Beef_Stew_R();
        Skewers_Flatter_R();
        Steak_R();
        Grilled_Salmon_R();
    }

    private void MashMellow_R()
    {
        // 마쉬멜로우 구이
        List<int> Temp = new List<int> { 200011 };
        _recipe_D.Add((int)Cooking_Type.Mashmellow, Temp);
    }

    private void Beef_Stew_R()
    {
        // 비프스튜
        List<int> Temp = new List<int> {111101, 410001, 510001 };
        _recipe_D.Add((int)Cooking_Type.Beef_Stew, Temp);
    }

    private void Skewers_Flatter_R()
    {
        // 꼬치플레터
        List<int> Temp = new List<int> { 111011, 610011, 810011 };
        _recipe_D.Add((int)Cooking_Type.Skewers_Flatter, Temp);
    }

    private void Steak_R()
    {
        // 스테이크
        List<int> Temp = new List<int> { 101101, 610001 };
        _recipe_D.Add((int)Cooking_Type.Steak, Temp);
    }

    private void Grilled_Salmon_R()
    {
        // 연어구이
        List<int> Temp = new List<int> { 311101, 710001 };
        _recipe_D.Add((int)Cooking_Type.Grilled_Salmon, Temp);
    }



}
