using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public List<int> Cooking = new List<int>();
    public GameObject[] Cooks;

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
            Ingredient ingred = collision.gameObject.GetComponent<Ingredient>();

            if (!Cooking.Contains(ingred.CheckCookIdx())) Cooking.Add(ingred.CheckCookIdx());
            Cooks[UiManager.instance.Num].SetActive(true);
            Destroy(collision.gameObject);

        }
    }

    public int ch_Reward()
    {
        Debug.Log(UiManager.instance.Num);
        Cooks[UiManager.instance.Num].SetActive(false);
        return RewardSystem.instance.RecipeCheck(Cooking, UiManager.instance.Num);
    }
}
