using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dish"))
        {
            Dish dish = other.gameObject.GetComponent<Dish>();
            {
                int starCount = dish.ch_Reward();

                UiManager.instance.OnStar(starCount);
            }
        }
    }
}
