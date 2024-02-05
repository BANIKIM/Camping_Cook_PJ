using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilledSystem : MonoBehaviour
{
    public Material[] mat = new Material[3];

    //https://cagongman.tistory.com/64
    private int grilled_stat = 0;

    public void ChangeMat()
    {
        grilled_stat = ++grilled_stat
    }

}
