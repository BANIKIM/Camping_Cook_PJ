using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_Complete : MonoBehaviour
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
            UiManager.instance.Update_CookUI.OffUpdate();
            GameObject box = GameObject.FindWithTag("Box");
            Destroy(box);
            Destroy(transform);
            //비활성화 한번 넣어주면 됨 todo(관영씨 주말만으로 다 해줬으면 좋겠어요)
        }
    }
}
