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
    // Dictionary (�丮 / ������)
    public Dictionary<int, List<int>> _recipePrep_D = new Dictionary<int, List<int>>();
    public Dictionary<int, List<int>> _recipeCook_D = new Dictionary<int, List<int>>();

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
        // ������ο� ����
        List<int> perptemp = new List<int> { 20001 };
        List<int> cooktemp = new List<int> { 21 };
        _recipePrep_D.Add((int)Cooking_Type.Mashmellow, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Mashmellow, cooktemp);
    }

    private void Beef_Stew_R()
    {
        // ������Ʃ
        List<int> perptemp = new List<int> { 11110, 41000, 51000 };
        List<int> cooktemp = new List<int> { 11, 41, 51 };
        _recipePrep_D.Add((int)Cooking_Type.Beef_Stew, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Beef_Stew, cooktemp);
    }

    private void Skewers_Flatter_R()
    {
        // ��ġ�÷���
        List<int> perptemp = new List<int> { 11111, 61001, 81001 };
        List<int> cooktemp = new List<int> { 11, 61, 81 };
        _recipePrep_D.Add((int)Cooking_Type.Skewers_Flatter, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Skewers_Flatter, cooktemp);
    }

    private void Steak_R()
    {
        // ������ũ
        List<int> perptemp = new List<int> { 11110, 61000 };
        List<int> cooktemp = new List<int> { 11, 61 };
        _recipePrep_D.Add((int)Cooking_Type.Steak, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Steak, cooktemp);
    }

    private void Grilled_Salmon_R()
    {
        // �����
        List<int> perptemp = new List<int> { 31110, 71000 };
        List<int> cooktemp = new List<int> { 31, 71 };
        _recipePrep_D.Add((int)Cooking_Type.Grilled_Salmon, perptemp);
        _recipeCook_D.Add((int)Cooking_Type.Grilled_Salmon, cooktemp);
    }



}
