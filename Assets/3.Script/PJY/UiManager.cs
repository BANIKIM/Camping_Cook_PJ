using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private UpdateCookUI update_CookUI;

    public UpdateCookUI Update_CookUI
    {
        get
        {
            return update_CookUI;
        }
    }
    [SerializeField]
    private CookingTimer cookingTimer;

    public CookingTimer CookingTimer
    {
        get
        {
            return cookingTimer;
        }
    }
    [SerializeField]
    private RecipesUI recipesUI;

    public RecipesUI RecipesUI
    {
        get
        {
            return recipesUI;
        }
    }
    [SerializeField]
    private ExpUI expUI;
    public ExpUI ExpUI
    {
        get
        {
            return expUI;
        }
    }
   
}
