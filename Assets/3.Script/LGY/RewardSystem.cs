using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem instance = null;

    public int star_count = 3;

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
    }


    public void RecipeCheck(List<int> dish, int cookidx)
    {
        List<int> recipe = CookManager.instance.Recipe_C(cookidx);

        // 식재료 개수가 다를 때 ex) 레시피는 4개인데 내가만든 요리는 3개면 별 개수 -1
        if (!recipe.Count.Equals(dish.Count)) 
        {
            star_count--;
        }

        for (int i = 0; i < dish.Count; i++)
        {
            //요리에 있는 식재료가 레시피에 없으면 -1
            if(recipe.Contains(dish[i]).Equals(false))
            {
                star_count--;
                break;
            }
        }


    }

}
