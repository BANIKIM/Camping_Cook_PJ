using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputIngred : MonoBehaviour
{
    public bool inputBeef = false;
    public bool inputCarrot = false;
    public bool inputPotato = false;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "beef":
                inputBeef = true;
                Destroy(other.gameObject);
                Invoke("ReturnBool", 0.5f);
                break;

            case "carrot":
                inputCarrot = true;
                Destroy(other.gameObject);
                Invoke("ReturnBool", 0.5f);
                break;

            case "potato":
                inputPotato = true;
                Destroy(other.gameObject);
                Invoke("ReturnBool", 0.5f);
                break;
        }
    }

    private void ReturnBool()
    {
        inputBeef = false;
        inputCarrot = false;
        inputPotato = false;
    }
}
