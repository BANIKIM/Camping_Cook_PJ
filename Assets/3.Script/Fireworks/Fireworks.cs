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
        if (fountain) rig.AddForce(Vector3.up * random_addForce);//생성되고 위로 튀어간다
        time = Random.Range(1, 2);//터지는 시간랜덤
    }

    private void Update()
    {
        if(!fire)retime += Time.deltaTime;

        if (time < retime)
        {
            int num = Random.Range(0, Firework.Length);
            rig.isKinematic = true;
            Firework[num].SetActive(true); //랜덤으로 다른 이펙트가 터짐
            fire = true;
            retime = 0f;
            Destroy(gameObject, 8f);
        }
    }
}
