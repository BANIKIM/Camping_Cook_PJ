using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Skewer : MonoBehaviour
{
    [SerializeField] private List<Transform> _stickpos;
    [SerializeField] private LayerMask _cookLayer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6 && !_stickpos.Count.Equals(0))
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            if (ingred.skewer_ingred.skewer_state.Equals(Skewer_State.Idle))
            {
                XRGrabInteractable xrgrab = other.gameObject.GetComponent<XRGrabInteractable>();
                xrgrab = null;

                ingred.skewer_ingred.Change_Skewer_State(Skewer_State.Inserted);
                other.gameObject.transform.parent = gameObject.transform;     // ²¿Ä¡¿¡ »ó¼Ó
                other.gameObject.transform.position = _stickpos[0].position;        // ²¿Ä¡¿¡ ³¢¿ò
                _stickpos.RemoveAt(0);
            }

        }
    }
}
