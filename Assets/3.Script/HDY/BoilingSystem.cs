using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilingSystem : MonoBehaviour
{
    /*
     ���̱� ����
     ���̱� �ܰ� 3 -> 0 1 2
     start 0�ܰ�
     time >= 8 -> 1�ܰ�
     time >= 10 -> 2�ܰ�
     ���̱� �ܰ�� ���� ������ ��

     ����
     ���� + �� (����ᰡ ����ȭ��)
     ���� + �� (����ᰡ ��Ÿ��) + ����� ���� (������ ������ Ÿ�̸� �ʱ�ȭ)

     �͹��̰ų� ��ᰡ �� �ȵ��� ���� �� �־�� ��
     
     ���� ���·θ� ���̱� �Ǻ�
     */

    [SerializeField] GameObject freshWater;
    [SerializeField] GameObject SlicedCarrot;
    [SerializeField] GameObject SlicedBeef;
    [SerializeField] GameObject SlicedPotato;

    private bool pour_water = false;
    public bool heat = false;
    private int add_food = 0;

    private Slice_Obj sliceObj;

    private void Start()
    {
        sliceObj = GetComponent<Slice_Obj>();
    }

    private void Update()
    {
        MyInput();
        Debug.Log(add_food);

        if(add_food >= 3)
        {
            Debug.Log("��ᰡ �� ��");
        }
    }
    
    private void MyInput()
    {
        bool AddIngred = pour_water && (sliceObj.slice_state == Slice_State.Slice_Step1
                                        || sliceObj.slice_state == Slice_State.Slice_Step2
                                        || sliceObj.slice_state == Slice_State.Slice_Step3);

        if (Input.GetKeyDown(KeyCode.Q)) //��� �ִ� ���� �ٲ� ��
        {
            Pouring();
        }

        if (AddIngred)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SlicedCarrot.SetActive(true);
                add_food++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                SlicedBeef.SetActive(true);
                add_food++;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SlicedPotato.SetActive(true);
                add_food++;
            }
        }
    }

    private void Pouring()
    {
        freshWater.SetActive(true); //���� ���
        pour_water = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrillGrate"))
        {
            heat = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrillGrate"))
        {
            heat = false;
        }
    }

}
