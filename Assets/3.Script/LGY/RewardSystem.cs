using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem instance = null;

    public int star_count = 3;

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


    public void RecipeCheck(int[] dish, int cookidx)
    {
        q_sort.Sort_Start(dish, 0, dish.Length - 1);    // 정렬 실행
        int[] recipe = CookManager.instance.Recipe_C(cookidx);

        // 식재료 개수가 다를 때 ex) 레시피는 4개인데 내가만든 요리는 3개면 별 개수 -1
        if (!recipe.Length.Equals(dish.Length)) 
        {
            star_count--;
        }

        if(dish[0].Equals(0)) // 정렬 이후라 0번째가 Trash라면 별 개수 -1
        {
            star_count--;
        }



    }

}
