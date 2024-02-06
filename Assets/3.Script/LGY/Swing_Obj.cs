using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing_Obj : MonoBehaviour
{
    private Vector3 presiousPos; // ���� ��ġ
    [SerializeField] private LayerMask interaction_layer;

    [SerializeField] float cutting_speed = 100f;

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 5);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, interaction_layer))
        {
            // position���� ���� ���͸� ���ϰ�, ���⺤�Ϳ� cube�� transfrom.up ������ ��
            if (Vector3.Angle(transform.position - presiousPos, hit.transform.up) >= cutting_speed) 
            {
                Slice_Obj slice_obj = hit.transform.GetComponent<Slice_Obj>();
                slice_obj.current_slice_count++;
            }
        }

        presiousPos = transform.position;
    }

}
