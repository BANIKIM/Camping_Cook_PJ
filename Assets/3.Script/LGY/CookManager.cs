using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RecipeSetting))]
[RequireComponent(typeof(SpawnIngredient))]

public class CookManager : MonoBehaviour
{
    public static CookManager instance = null;

    private RecipeSetting recipeset;
    private SpawnIngredient spawningred;

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
        TryGetComponent(out recipeset);
        TryGetComponent(out spawningred);

        recipeset.SetDefaultRecipe();
    }

    public List<int> Recipe_C(int idx)    // ������ �θ��� �޼���
    {
        return recipeset.recipe_D[idx];
    }

    public void Spawn(int idx)  // idx�� �丮��ȣ
    {
        spawningred.Spawn(idx);
    }
}
