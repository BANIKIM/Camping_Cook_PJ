using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_heat : MonoBehaviour
{
    public bool tool_heat = false;//가열 여부


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            tool_heat = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            tool_heat = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            tool_heat = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Fire"))
        {
            tool_heat = false;
        }
    }
}
