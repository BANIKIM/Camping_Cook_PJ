using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_Complete : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dish") && GameManager.instance.isCookingStart)
        {
            
            Dish dish = other.gameObject.GetComponent<Dish>();

            TabletManager.instance._ui_Star.StarUpdate(dish.ch_Reward());
            GameManager.instance.StopCooking();
            dish.onech = false;
            GameManager.instance._currentExp += 50; // 경험치 50씩 추가한다.
            GameObject box = GameObject.FindWithTag("Box");
            Destroy(box);
            GameObject[] trash = GameObject.FindGameObjectsWithTag("Food");
            for (int i = 0; i < trash.Length; i++)
            {
                Destroy(trash[i]);
            }
        }
    }
}
