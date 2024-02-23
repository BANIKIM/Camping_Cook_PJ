using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem instance = null;
    public Dish dish1;
    public int _starCount = 3;

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


    public int RecipeCheck(List<int> prepdish, List<int> cookdish, int cookidx)
    {
        List<int> preprecipe = CookManager.instance.PrepRecipe_C(cookidx);
        List<int> cookrecipe = CookManager.instance.CookRecipe_C(cookidx);

        _starCount = 3;

        // 식재료 개수가 다를 때 ex) 레시피는 4개인데 내가만든 요리는 3개면 별 개수 -1
        if (!preprecipe.Count.Equals(prepdish.Count))
        {
            Debug.Log("재료개수 다름");
            _starCount--;
        }
        for (int i = 0; i < prepdish.Count; i++)
        {
            //요리에 있는 식재료가 레시피에 없으면 -1
            if (preprecipe.Contains(prepdish[i]).Equals(false))
            {
                Debug.Log("손질 다름");
                _starCount--;
                break;
            }
        }
        for (int i = 0; i < cookdish.Count; i++)
        {
            //요리에 있는 식재료가 레시피에 없으면 -1
            if (cookrecipe.Contains(cookdish[i]).Equals(false))
            {
                Debug.Log("굽기 다름");
                _starCount--;
                break;
            }
        }

        prepdish.Clear();
        cookdish.Clear();
        return _starCount;

    }

}
