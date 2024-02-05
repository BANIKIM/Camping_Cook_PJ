using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public bool saulting = false;
    public bool peppering = false;

    private void Update()
    {
        WhatSeasoning(); //소금과 후추 뿌려졌다는 게 계속 뜨게 됨 고치고 싶음
    }

    private void WhatSeasoning()
    {
        if (saulting)
        {
            Debug.Log("소금");
        }
        if (peppering)
        {
            Debug.Log("후추");
        }
    }

}
