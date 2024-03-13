using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat_Test : MonoBehaviour
{
    private MeshRenderer renderer;
    public Material tanmat;
    private float time;
    public float time_limit=10;


    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        if (renderer == null) Debug.Log("�Ž����� ��ã��");
    }

    private void OnTriggerStay(Collider other)
    {
        if(transform.gameObject.CompareTag("Down"))
        {
            time += Time.deltaTime;
            Debug.Log("���� ��������.");
            if(time> time_limit)
            {
                Material[] materials = renderer.materials;
                materials[0] = tanmat; // ���ϴ� ���͸���� ����
                renderer.materials = materials; // ����� ���͸��� ����
            }
        }
        if (transform.gameObject.CompareTag("Up"))
        {
            time += Time.deltaTime;
            Debug.Log("���� ��������.");
            if (time > time_limit)
            {
                Material[] materials = renderer.materials;
                materials[0] = tanmat; // ���ϴ� ���͸���� ����
                renderer.materials = materials; // ����� ���͸��� ����
            }
        }
    }
}
