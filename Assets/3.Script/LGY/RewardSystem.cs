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
        q_sort.Sort_Start(dish, 0, dish.Length - 1);    // ���� ����
        int[] recipe = CookManager.instance.Recipe_C(cookidx);

        // ����� ������ �ٸ� �� ex) �����Ǵ� 4���ε� �������� �丮�� 3���� �� ���� -1
        if (!recipe.Length.Equals(dish.Length)) 
        {
            star_count--;
        }

        if(dish[0].Equals(0)) // ���� ���Ķ� 0��°�� Trash��� �� ���� -1
        {
            star_count--;
        }



    }

}
