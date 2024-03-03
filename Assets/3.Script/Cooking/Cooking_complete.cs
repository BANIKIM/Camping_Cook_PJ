using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking_Complete : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dish"))
        {
            Dish dish = other.gameObject.GetComponent<Dish>();

            TabletManager.instance._ui_Star.StarUpdate(dish.ch_Reward());
            GameManager.instance.StopCooking();

            _audioSource.PlayOneShot(_audioSource.clip);

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
