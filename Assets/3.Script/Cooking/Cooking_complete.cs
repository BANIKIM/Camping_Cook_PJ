using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_Complete : MonoBehaviour
{
    public AudioSource CookEnd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dish"))
        {
            Dish dish = other.gameObject.GetComponent<Dish>();
            {

                int starCount = dish.ch_Reward();

                UiManager.instance.OnStar(starCount);
            }
            UiManager.instance.Update_CookUI.OffUpdate();
            CookEnd.PlayOneShot(CookEnd.clip);
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
