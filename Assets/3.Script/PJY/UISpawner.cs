using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawner : MonoBehaviour
{ 
    //일정 범위안에 들어오면 ui를 띄우는 스크립트
    public GameObject SpawnUI;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            SpawnUI.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnUI.SetActive(false);
        }
    }



}
