using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager instance = null;
    public Dish _dish;
    public int _starCount;

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

        if (prepdish.Count.Equals(0)) _starCount--;
        if (cookdish.Count.Equals(0)) _starCount--;

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
