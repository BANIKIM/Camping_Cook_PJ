using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public GameObject[] Firework;
    private Rigidbody rig;
    public float time;
    public float retime = 0f;
    private bool fire = false;
    public bool fountain;
    private int random_addForce;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        random_addForce = Random.Range(900, 1100);
        if (fountain) rig.AddForce(Vector3.up * random_addForce);//�����ǰ� ���� Ƣ���
        time = Random.Range(1, 2);//������ �ð�����
    }

    private void Update()
    {
        if(!fire)retime += Time.deltaTime;

        if (time < retime)
        {
            int num = Random.Range(0, Firework.Length);
            rig.isKinematic = true;
            Firework[num].SetActive(true); //�������� �ٸ� ����Ʈ�� ����
            fire = true;
            retime = 0f;
            Destroy(gameObject, 8f);
        }
    }
}
