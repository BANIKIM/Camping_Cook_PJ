using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawner : MonoBehaviour
{
    public GameObject SpawnUI;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {

            SpawnUI.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            SpawnUI.SetActive(false);
        }
    }



}
