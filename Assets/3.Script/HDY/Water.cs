using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private BoilingSystem boilingSys;

    private MeshRenderer rd;
    public Material one_step; //끓이기 1단계 material
    public Material second_step; //끓이기 2단계 material

    public float time;
    
    private void Start()
    {
        boilingSys = FindObjectOfType<BoilingSystem>();

        rd = GetComponent<MeshRenderer>();

        if (rd == null)
        {
            Debug.Log("MeshRenderer 못 찾음");
        }
    }

    private void Update()
    {
        ChangeMat();
    }

    private void ChangeMat()
    {
        if(boilingSys.heat)
        {
            time += Time.deltaTime;

            if(time >= 8)
            {
                Material[] mat = rd.materials;
                mat[0] = one_step;
                rd.materials = mat;
            }
            if(time >= 10)
            {
                Material[] mat = rd.materials;
                mat[0] = second_step;
                rd.materials = mat;
            }
        }
    }
}
