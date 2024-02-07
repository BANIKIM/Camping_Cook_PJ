using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private BoilingSystem boilingSys;

    private MeshRenderer rd;
    public Material one_step; //���̱� 1�ܰ� material
    public Material second_step; //���̱� 2�ܰ� material

    public float time;
    
    private void Start()
    {
        boilingSys = FindObjectOfType<BoilingSystem>();

        rd = GetComponent<MeshRenderer>();

        if (rd == null)
        {
            Debug.Log("MeshRenderer �� ã��");
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
