using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrilledSystem : MonoBehaviour
{
    // ������ �� ���� �߰�
    // ���� �߰�

    private new MeshRenderer renderer;
    public Material Cooked_mat;
    public Material Burnt_mat;

    [SerializeField] private TMP_Text text; 

    public float time;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        if (renderer == null) Debug.Log("�Ž����� ��ã��");
    }

    private void OnTriggerStay(Collider other)
    {
        if (transform.gameObject.CompareTag("DownMeat"))
        {
            time += Time.deltaTime;
            Debug.Log("���� ��������.");

            if (time >= 8)
            {
                Material[] materials = renderer.materials;
                materials[0] = Cooked_mat; // ���ϴ� ���͸���� ����
                renderer.materials = materials; // ����� ���͸��� ����
            }
            if (time >= 10)
            {
                Material[] materials = renderer.materials;
                materials[0] = Burnt_mat; 
                renderer.materials = materials; 
            }
        }

        if (transform.gameObject.CompareTag("UpMeat"))
        {
            time += Time.deltaTime;
            Debug.Log("���� ��������.");
           
            if (time >= 8)
            {
                Material[] materials = renderer.materials;
                materials[0] = Cooked_mat; 
                renderer.materials = materials; 
            }
            if (time >= 10)
            {
                Material[] materials = renderer.materials;
                materials[0] = Burnt_mat; 
                renderer.materials = materials; 
            }
        }
    }
}




