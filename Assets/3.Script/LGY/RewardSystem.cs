using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem instance = null;

    public int Star_Count = 0;

    public Quick_Sort q_sort;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }

        TryGetComponent<Quick_Sort>(out q_sort);
    }


    public void RecipeCheck(int[] AAA, int cookidx)
    {
        q_sort.Sort_Start(AAA, 0, AAA.Length - 1);    // 정렬 실행
        int[] recipe = CookManager.instance.Recipe_C(cookidx);

        if (recipe.Length.Equals(AAA.Length))
        {
            Star_Count++;
        }

        var count = 0;
        for (int i = 0; i < recipe.Length; i++)
        {
            if(AAA.Equals(recipe))
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count.Equals(recipe.Length)) Star_Count++;

    }

}
