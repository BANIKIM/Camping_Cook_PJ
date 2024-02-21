using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingreds;

    private void OnEnable()
    {
        for (int i = 0; i < _ingreds.Length; i++)
        {
            _ingreds[i].transform.parent = null;
        }
    }

}
