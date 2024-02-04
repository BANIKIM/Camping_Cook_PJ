using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Vector3 presiousPos; // ���� ��ġ
    LayerMask food_layer = 6;


    private void Update()
    {

        RaycastHit hit; // target
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, food_layer))
        {
            if (Vector3.Angle(transform.position - presiousPos, hit.transform.up) >= 130f) // position���� ���� ���͸� ���ϰ�, ���⺤�Ϳ� cube�� transfrom.up ������ ��
            {
                Ingredient ingredient = hit.transform.GetComponent<Ingredient>();
                ingredient.current_slice_count++;
            }
        }

        presiousPos = transform.position;
    }

}
