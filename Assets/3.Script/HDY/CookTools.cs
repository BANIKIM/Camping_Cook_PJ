using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookTools : MonoBehaviour
{
    [SerializeField] private Boiling boiling;
    [SerializeField] GameObject inLadle; //������ ���빰
    [SerializeField] GameObject inPlate; //�׸��� ���빰

    public Material[] inToolMat = new Material[3];

    private bool emptyLadle = true; //���ڰ� ����� ��

    private void Start()
    {
        boiling = FindObjectOfType<Boiling>();
        inLadle.GetComponent<MeshRenderer>().material = inToolMat[0];
        inPlate.GetComponent<MeshRenderer>().material = inToolMat[0];

        inLadle.SetActive(false);
        inPlate.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)//���ڿ� �׸��� ��ȣ�ۿ��� ����. ������ ���빰�� ���� �� ���ϱ� ����
    {
        if (other.CompareTag("PanEnter")) 
        {
            if (emptyLadle) //���ڰ� ����� ��
            {
                CopyMat_Ladle();
                emptyLadle = false;
            }
            else //���ڿ� ���빰�� �� ���� ��
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
            else //���ڿ� ���빰�� �� ���� ��
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

    public void Appear() //���빰 �����ֱ�
    {
        if (emptyLadle)
        {
            inLadle.SetActive(true);
        }
    }

    public void Disappear() //���빰 �������
    {
        inLadle.SetActive(false);
    }

    public void Appear_onPlate() //�׸��� �ױ�
    {
        inPlate.SetActive(true);
    }

}
