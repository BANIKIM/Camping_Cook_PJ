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
    }

    public List<int> Recipe_C(int idx)    // 레시피 부르는 메서드
    {
        return _recipeSetting._recipe_D[idx];
    }

    public void Spawn(int idx)  // idx는 요리번호
    {
            
        _spawnIngred.Spawn(idx);

    }

}
