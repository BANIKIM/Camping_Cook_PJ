using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawner : MonoBehaviour
{
    public GameObject SpawnUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hand"))
        {

            SpawnUI.SetActive(true);
           
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Hand"))
        {
            SpawnUI.SetActive(false);
        }
    }
  


}
