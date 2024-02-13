using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookManager : MonoBehaviour
{
    public static CookManager instance = null;

    private RecipeSetting recipeset;


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
        TryGetComponent<RecipeSetting>(out recipeset);

        recipeset.SetDefaultRecipe();
    }

    public int[] Recipe_C(int idx)    // ������ �θ��� �޼���
    {
        return recipeset.Recipe_D[idx];
    }

}
