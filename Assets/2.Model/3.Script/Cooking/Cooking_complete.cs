using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_Complete : MonoBehaviour
{
    public LiquidBoil liquidBoil;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dish") && GameManager.instance.isCookingStart)
        {
            
            Dish dish = other.gameObject.GetComponent<Dish>();

            TabletManager.instance._tablet_Star.StarUpdate(dish.ch_Reward());
            GameManager.instance.StopCooking();
            dish.onech = false;
            GameManager.instance.CampingExpCheck(50);
            liquidBoil.LiquidReset();//물머테리얼도 초기화
            liquidBoil.CookReset();//초기화
        }
    }
}
