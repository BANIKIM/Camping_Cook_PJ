using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Cook_Stick : MonoBehaviour
{

    public GameObject A;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            XRGrabInteractable xrgrab = collision.gameObject.GetComponent<XRGrabInteractable>();
            xrgrab = null;

            Debug.Log("음식음식");
            collision.gameObject.transform.parent = A.transform;
            collision.gameObject.transform.localScale = A.transform.localScale;
            //collision.transform.SetParent(transform);
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}