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
        Debug.DrawRay(transform.position, transform.up * 1.5f, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.up, out hit))
        {
            //Debug.Log("�̰��� " + hit.collider.gameObject.name + "��.");

            if(hit.collider.gameObject.name == "Meat")
            {
                Debug.Log("��� ����");
            }
        }
    }
}
