using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework_firing : MonoBehaviour
{
    public bool firing = false;
    public GameObject[] firing_pad; // �߻���ӿ�����Ʈ
    public GameObject aa;


    private void FixedUpdate()
    {
        
        //Ʈ�簡 �ȴٸ�
        if(firing)
        {
            for (int i = 0; i < firing_pad.Length; i++)
            {
              GameObject clen = Instantiate(aa, firing_pad[0].transform);
                //�ʿ��Ѱ� �о������ ������ �����µ� ���� �ɸ��� �ð��ε�
                clen.transform.GetChild(0).gameObject.SetActive(true);// Ŭ���� ���� ����Ʈ Ȱ��ȭ

            }
        }
    }
}
