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

        // ����� ������ �ٸ� �� ex) �����Ǵ� 4���ε� �������� �丮�� 3���� �� ���� -1
        if (!preprecipe.Count.Equals(prepdish.Count))
        {
            Debug.Log("��ᰳ�� �ٸ�");
            _starCount--;
        }
        for (int i = 0; i < prepdish.Count; i++)
        {
            //�丮�� �ִ� ����ᰡ �����ǿ� ������ -1
            if (preprecipe.Contains(prepdish[i]).Equals(false))
            {
                Debug.Log("���� �ٸ�");
                _starCount--;
                break;
            }
        }
        for (int i = 0; i < cookdish.Count; i++)
        {
            //�丮�� �ִ� ����ᰡ �����ǿ� ������ -1
            if (cookrecipe.Contains(cookdish[i]).Equals(false))
            {
                Debug.Log("���� �ٸ�");
                _starCount--;
                break;
            }
        }

        prepdish.Clear();
        cookdish.Clear();
        return _starCount;

    }

}
