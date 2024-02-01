using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private List<Transform> stickpos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food"))
        {
            Ingredient food = other.gameObject.GetComponent<Ingredient>();
            if(food.slice_state.Equals(Slice_State.Slice_Step2) && !stickpos.Count.Equals(0))
            {
                other.gameObject.transform.position = stickpos[0].position;   // ²¿Ä¡¿¡ ³¢¿ò
                other.gameObject.transform.parent = gameObject.transform;     // ²¿Ä¡¿¡ »ó¼Ó
                stickpos.RemoveAt(0);
            }
        }
    }
}
