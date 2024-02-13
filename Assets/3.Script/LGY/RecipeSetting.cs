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
        // ������ο� ����
        int[] Temp = new int[1] { 1 };
        Recipe_D.Add((int)Recipe_Type.Mashmellow, Temp);
    }

    private void Beef_Stew_R()
    {
        // ������Ʃ
        int[] Temp = new int[3] { 2, 7, 8 };
        Recipe_D.Add((int)Recipe_Type.Beef_Stew, Temp);
    }

    private void Skewers_Flatter_R()
    {
        // ��ġ�÷���
        int[] Temp = new int[3] { 3, 9, 11 };
        Recipe_D.Add((int)Recipe_Type.Skewers_Flatter, Temp);
    }

    private void Steak_R()
    {
        // ������ũ
        int[] Temp = new int[2] { 4, 10 };
        Recipe_D.Add((int)Recipe_Type.Steak, Temp);
    }

    private void Grilled_Salmon_R()
    {
        // �����
        int[] Temp = new int[2] { 5, 6 };
        Recipe_D.Add((int)Recipe_Type.Grilled_Salmon, Temp);
    }



}
