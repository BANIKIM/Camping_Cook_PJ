using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasoning : MonoBehaviour
{
    /*
     raycast�� �ұ��뿡 �������� �ȱ�
     ���� raycast�� ����
     ����� bool seasoning = true;
     
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
                Debug.Log("��� ����");
            }
            else
            {
                Debug.Log("��� ��");
            }
        }
    }
}
