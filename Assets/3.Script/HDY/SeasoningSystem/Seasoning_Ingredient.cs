using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasoning_Ingredient : MonoBehaviour
{
    public bool issalt { get; private set; }
    public bool ispepper { get; private set; }

    private void Start()
    {
        issalt = false;
        ispepper = false;
    }

    public void AddSeasoning(int idx)
    {
        switch (idx)
        {
            case 0:
                if (!issalt) issalt = true;
                break;
            case 1:
                if (!ispepper) ispepper = true;
                break;
            default:
                break;
        }

    }
}
