using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiling : MonoBehaviour
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

    public int water_HP = 0; //���� hp
    public int ingred_HP = 5;
    public float All_hp = 0;

    public int boilingTime;
    public float time;

    private void Update()
    {
        MyInput();
        time += Time.deltaTime;
    }

    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //��� �ִ� ���� �ٲ� ��
        {
            freshWater.SetActive(true); //���� ���
            pour_water = true;
        }

        if (pour_water)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SlicedCarrot.SetActive(true);
                All_hp = All_hp+ ingred_HP;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SlicedBeef.SetActive(true);
                All_hp = All_hp + ingred_HP;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SlicedPotato.SetActive(true);
                All_hp = All_hp + ingred_HP;
            }
        }
        else
        {
            Debug.Log("�� ���̴� ��Ḧ ���� ����");
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GrillGrate"))
        {
            All_hp -= Time.deltaTime;
            Debug.Log("����� �ϴ� �ð�: " + All_hp);
        }
    }
}
