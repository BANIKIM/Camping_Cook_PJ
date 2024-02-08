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
        if (Input.GetKeyDown(KeyCode.Q)) //��� �ִ� ���� �ٲ� ��
        {
            Pouring();
        }
        if (Input.GetKeyDown(KeyCode.W) && pour_water)
        {
            InputCarrot();
        }
        if (Input.GetKeyDown(KeyCode.E) && pour_water) //��� �ִ� ���� �ٲ� ��
        {
            InputBeef();
        }
        if (Input.GetKeyDown(KeyCode.R) && pour_water) //��� �ִ� ���� �ٲ� ��
        {
            InputPotato();
        }
    }

    private void Pouring()
    {
        freshWater.SetActive(true); //���� ���
        pour_water = true;
    }
    private void InputCarrot()
    {
        SlicedCarrot.SetActive(true);
        add_food++;
    }
    private void InputBeef()
    {
        SlicedBeef.SetActive(true);
        add_food++;
    }
    private void InputPotato()
    {
        SlicedPotato.SetActive(true);
        add_food++;
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
