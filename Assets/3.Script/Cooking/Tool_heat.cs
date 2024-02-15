using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_heat : MonoBehaviour
{
    public bool tool_heat = false;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            tool_heat = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            tool_heat = true;
        }
    }

}
