using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Vector3 presiousPos; // 이전 위치
    LayerMask food_layer = 6;


    private void Update()
    {

        RaycastHit hit; // target
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, food_layer))
        {
            if (Vector3.Angle(transform.position - presiousPos, hit.transform.up) >= 130f) // position으로 방향 벡터를 구하고, 방향벡터와 cube의 transfrom.up 각도를 비교
            {
                Ingredient ingredient = hit.transform.GetComponent<Ingredient>();
                ingredient.current_slice_count++;
            }
        }

        presiousPos = transform.position;
    }

}
