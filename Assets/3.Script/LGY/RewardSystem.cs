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


    public int RecipeCheck(List<int> dish, int cookidx)
    {
        List<int> recipe = CookManager.instance.Recipe_C(cookidx);

        // ����� ������ �ٸ� �� ex) �����Ǵ� 4���ε� �������� �丮�� 3���� �� ���� -1

        if (!recipe.Count.Equals(dish.Count)) _starCount--;

        for (int i = 0; i < dish.Count; i++)
        {
            //�丮�� �ִ� ����ᰡ �����ǿ� ������ -1
            if (recipe.Contains(dish[i]).Equals(false))
            {
                _starCount--;
                break;
            }
        }

        dish.Clear();
        return _starCount;

    }

}
