using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookTools : MonoBehaviour
{
    [SerializeField] private Boiling boiling;
    [SerializeField] GameObject inLadle; //국자의 내용물
    [SerializeField] GameObject inPlate; //그릇의 내용물

    public Material[] inToolMat = new Material[3];

    private bool emptyLadle = true; //국자가 비었을 때

    private void Start()
    {
        boiling = FindObjectOfType<Boiling>();
        inLadle.GetComponent<MeshRenderer>().material = inToolMat[0];
        inPlate.GetComponent<MeshRenderer>().material = inToolMat[0];

        inLadle.SetActive(false);
        inPlate.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)//국자와 그릇의 상호작용을 나눔. 국자의 내용물이 제때 안 변하기 때문
    {
        if (other.CompareTag("PanEnter")) 
        {
            if (emptyLadle) //국자가 비었을 때
            {
                CopyMat_Ladle();
                emptyLadle = false;
            }
            else //국자에 내용물이 차 있을 때
            {
                Disappear();
                //Appear_onPlate();
                emptyLadle = true;
            }
        }

        if (other.CompareTag("Plate"))
        {
            if (emptyLadle)
            {
                CopyMat_Plate();
                emptyLadle = false;
            }
            else //국자에 내용물이 차 있을 때
            {
                Disappear();
                Appear_onPlate();
                emptyLadle = true;
            }
        }
    }

    private void CopyMat_Plate()
    {
        if (boiling.stew_mat)
        {
            inPlate.GetComponent<MeshRenderer>().material = inToolMat[1];
        }
        else if (!boiling.stew_mat && boiling.burnt_mat)
        {
            inPlate.GetComponent<MeshRenderer>().material = inToolMat[2];
        }
    }

    private void CopyMat_Ladle()
    {
        if (boiling.stew_mat)
        {
            inLadle.GetComponent<MeshRenderer>().material = inToolMat[1];
        }
        else if (!boiling.stew_mat && boiling.burnt_mat)
        {
            inLadle.GetComponent<MeshRenderer>().material = inToolMat[2];
        }
    }

    public void Appear() //내용물 보여주기
    {
        if (emptyLadle)
        {
            inLadle.SetActive(true);
        }
    }

    public void Disappear() //내용물 사라지기
    {
        inLadle.SetActive(false);
    }

    public void Appear_onPlate() //그릇에 붓기
    {
        inPlate.SetActive(true);
    }

}
