using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUi : MonoBehaviour
{
    public GameObject Start;
    public GameObject Quit;

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Box"))
        {
            Start.SetActive(true);

        }
        // 만약 충돌한 객체의 태그가 "Food"라면
        else if (other.CompareTag("Food"))
        {
            Quit.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Start.SetActive(false);

        }
        // 만약 충돌한 객체의 태그가 "Food"라면
        else if (other.CompareTag("Food"))
        {
            Quit.SetActive(false);
        }
    }
}
