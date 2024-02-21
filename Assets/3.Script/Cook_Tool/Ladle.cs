using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladle : MonoBehaviour
{
    public GameObject Liquidin;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Liquid"))
        {
            Liquidin.SetActive(true);
            Liquidin.gameObject.GetComponent<MeshRenderer>().material = other.GetComponent<Ingredient>()._crossMat;
        }
    }
}
