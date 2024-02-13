using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Recipe_Type
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
    public Dictionary<int, int[]> Recipe_D = new Dictionary<int, int[]>();


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
        int[] Temp = new int[1] { 1 };
        Recipe_D.Add((int)Recipe_Type.Mashmellow, Temp);
    }

    private void Beef_Stew_R()
    {
        // 비프스튜
        int[] Temp = new int[3] { 2, 7, 8 };
        Recipe_D.Add((int)Recipe_Type.Beef_Stew, Temp);
    }

    private void Skewers_Flatter_R()
    {
        // 꼬치플레터
        int[] Temp = new int[3] { 3, 9, 11 };
        Recipe_D.Add((int)Recipe_Type.Skewers_Flatter, Temp);
    }

    private void Steak_R()
    {
        // 스테이크
        int[] Temp = new int[2] { 4, 10 };
        Recipe_D.Add((int)Recipe_Type.Steak, Temp);
    }

    private void Grilled_Salmon_R()
    {
        // 연어구이
        int[] Temp = new int[2] { 5, 6 };
        Recipe_D.Add((int)Recipe_Type.Grilled_Salmon, Temp);
    }



}
