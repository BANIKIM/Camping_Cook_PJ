using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecipeSetting))]
[RequireComponent(typeof(SpawnIngredient))]

public class CookManager : MonoBehaviour
{
    public static CookManager instance = null;

    private RecipeSetting _recipeSetting;
    private SpawnIngredient _spawnIngred;

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

    private void Start()
    {
        TryGetComponent(out _recipeSetting);
        TryGetComponent(out _spawnIngred);

        _recipeSetting.SetDefaultRecipe();

        int[] test = new int[2] { (int)Ingredient_Type.Beef, (int)Ingredient_Type.Onion };

        Spawn(test);
    }

    public List<int> Recipe_C(int idx)    // 레시피 부르는 메서드
    {
        return _recipeSetting._recipe_D[idx];
    }

    public void Spawn(int[] idxs)  // idx는 요리번호
    {
        for (int i = 0; i < idxs.Length; i++)
        {
            _spawnIngred.Spawn(idxs[i]);

        }
    }
}
