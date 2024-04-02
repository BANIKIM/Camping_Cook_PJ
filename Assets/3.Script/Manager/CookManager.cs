using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cooking_Type
{
    Marshmallow = 0,
    Beef_Stew,
    Skewers_Flatter,
    Beef_Steak,
    Salmon_Steak,
}

public enum Cooking_Difficulty 
{
    Easy,
    Normal,
    Hard
}

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
    }

    // 레시피 부르는 메서드
    public List<int> PrepRecipe_C(int idx)    
    {
        return _recipeSetting._recipePrep_D[idx];
    }

    public List<int> CookRecipe_C(int idx)
    {
        return _recipeSetting._recipeCook_D[idx];
    }

    public void Spawn(int idx)  // idx는 요리번호
    {
            
        _spawnIngred.Spawn(idx);

    }

}
