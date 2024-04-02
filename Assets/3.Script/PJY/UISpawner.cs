using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawner : MonoBehaviour
{ 
    //���� �����ȿ� ������ ui�� ���� ��ũ��Ʈ
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
