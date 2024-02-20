using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    List<int> Cooking = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            Cooking.Add(ingred.CheckCookIdx());
        }
    }


    public int ch_Reward()
    {
        return RewardSystem.instance.RecipeCheck(Cooking, UiManager.instance.Num);
    }
}
