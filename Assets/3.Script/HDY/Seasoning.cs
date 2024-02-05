using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasoning : MonoBehaviour
{
    /*
     raycast로 소금통에 수직으로 꽂기
     고기는 raycast를 감지
     고기의 bool seasoning = true;
     
     */

    //public float lineSize = 2f;

    private void Update()
    {
        CheckMeat();
    }

    private void CheckMeat()
    {
        Debug.DrawRay(transform.position, transform.up*0.5f, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up, out hit))
        {

            if(hit.collider.gameObject.name == "meat")
            {
                Debug.Log("양념 시작");
            }
            else
            {
                Debug.Log("양념 끝");
            }
        }
    }
}
