using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
   public List<int> Cooking = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            Cooking.Add(ingred.CheckCookIdx());
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (!collision.gameObject.CompareTag("Liquid"))
            {
                Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();
                Cooking.Add(ingred.CheckCookIdx());
                Destroy(collision.gameObject);
            }
            
        }
    }

    public int ch_Reward()
    {
        Debug.Log(UiManager.instance.Num);
        return RewardSystem.instance.RecipeCheck(Cooking, UiManager.instance.Num);
    }
}
