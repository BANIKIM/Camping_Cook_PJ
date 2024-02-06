using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing_Obj : MonoBehaviour
{
    private Vector3 presiousPos; // 이전 위치
    [SerializeField] private LayerMask interaction_layer;

    [SerializeField] float cutting_speed = 100f;

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 5);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, interaction_layer))
        {
            // position으로 방향 벡터를 구하고, 방향벡터와 cube의 transfrom.up 각도를 비교
            if (Vector3.Angle(transform.position - presiousPos, hit.transform.up) >= cutting_speed) 
            {
                Slice_Obj slice_obj = hit.transform.GetComponent<Slice_Obj>();
                slice_obj.current_slice_count++;
            }
        }

        presiousPos = transform.position;
    }

}
