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
    // Dictionary (�丮 / ������)
    public Dictionary<int, List<int>> recipe_D = new Dictionary<int, List<int>>();

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
        List<int> Temp = new List<int> { 200011 };
        recipe_D.Add((int)Recipe_Type.Mashmellow, Temp);
    }

    private void Beef_Stew_R()
    {
        // ������Ʃ
        List<int> Temp = new List<int> { 111101, 410001, 510001 };
        recipe_D.Add((int)Recipe_Type.Beef_Stew, Temp);
    }

    private void Skewers_Flatter_R()
    {
        // ��ġ�÷���
        List<int> Temp = new List<int> { 111011, 610011, 810011 };
        recipe_D.Add((int)Recipe_Type.Skewers_Flatter, Temp);
    }

    private void Steak_R()
    {
        // ������ũ
        List<int> Temp = new List<int> { 101101, 610001 };
        recipe_D.Add((int)Recipe_Type.Steak, Temp);
    }

    private void Grilled_Salmon_R()
    {
        // �����
        List<int> Temp = new List<int> { 311101, 710001 };
        recipe_D.Add((int)Recipe_Type.Grilled_Salmon, Temp);
    }



}
