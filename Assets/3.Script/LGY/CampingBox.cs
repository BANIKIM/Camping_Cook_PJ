using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampingBox : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingredients;

    private void Start()
    {
        for (int i = 0; i < _ingredients.Length; i++)
        {
            _ingredients[i].transform.parent = null;
        }
    }
}
