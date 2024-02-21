using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Skewer : MonoBehaviour
{
    [SerializeField] private List<Transform> _stickPos;
    [SerializeField] private LayerMask _cookLayer;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6 && !_stickPos.Count.Equals(0))
        {
            Ingredient ingred = other.gameObject.GetComponent<Ingredient>();
            if (ingred._skewerIngred.skewer_state.Equals(Skewer_State.Idle))
            {
                XRGrabInteractable xrgrab = other.gameObject.GetComponent<XRGrabInteractable>();
                xrgrab = null;

                ingred._skewerIngred.Change_Skewer_State(Skewer_State.Inserted);
                other.gameObject.transform.parent = gameObject.transform;     // ²¿Ä¡¿¡ »ó¼Ó
                other.gameObject.transform.position = _stickPos[0].position;        // ²¿Ä¡¿¡ ³¢¿ò
                _stickPos.RemoveAt(0);
            }

        }
    }
}
