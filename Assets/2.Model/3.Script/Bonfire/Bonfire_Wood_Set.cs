using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire_Wood_Set : MonoBehaviour
{
    [SerializeField] private GameObject Wood;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wood"))
        {
            for (int i = 0; i < Wood.transform.childCount; i++)
            {
                if (Wood.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    Wood.transform.GetChild(i).gameObject.SetActive(true);
                    Destroy(collision.gameObject);
                }
            }            
        }
    }
}
