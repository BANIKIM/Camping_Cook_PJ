using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public static RewardSystem instance = null;

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

        Debug.Log("�丮�Ѱ�");

        Debug.Log(dish.Count);
        for (int i = 0; i < dish.Count; i++)
        {
            Debug.Log(dish[i]);
        }

        Debug.Log("������");

        Debug.Log(recipe.Count);
        for (int i = 0; i < recipe.Count; i++)
        {
            Debug.Log(recipe[i]);
        }
        Debug.Log("==================");

        // ����� ������ �ٸ� �� ex) �����Ǵ� 4���ε� �������� �丮�� 3���� �� ���� -1
        if (!recipe.Count.Equals(dish.Count)) 
        {
            Debug.Log("����� ������ �޶�");
            _starCount--;
        }

        for (int i = 0; i < dish.Count; i++)
        {
            //�丮�� �ִ� ����ᰡ �����ǿ� ������ -1
            if(recipe.Contains(dish[i]).Equals(false))
            {
                Debug.Log("���ǽð� Ʋ�Ⱦ�");
                _starCount--;
                break;
            }
        }
        Debug.Log("����" + _starCount);
        return _starCount;

    }

}
