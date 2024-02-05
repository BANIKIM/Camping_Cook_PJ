using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Vector3 presiousPos; // ���� ��ġ
    private LayerMask food_layer = 6;

    [SerializeField] float cutting_speed = 100f;

    private void FixedUpdate()
    {
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, food_layer))
        {
            // position���� ���� ���͸� ���ϰ�, ���⺤�Ϳ� cube�� transfrom.up ������ ��
            if (Vector3.Angle(transform.position - presiousPos, hit.transform.up) >= cutting_speed) 
            {
                Ingredient ingredient = hit.transform.GetComponent<Ingredient>();
                ingredient.current_slice_count++;
            }
        }

        presiousPos = transform.position;
    }

}
