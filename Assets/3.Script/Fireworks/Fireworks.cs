using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public GameObject Firework;
    private Rigidbody rig;
    public float time;
    public float retime = 0f;
    private bool fire = false;
    public bool fountain;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        if(!fountain)rig.AddForce(Vector3.up*1000);
        time = Random.Range(2, 4);
    }

    private void Update()
    {
        if(!fire)retime += Time.deltaTime;

        if (time < retime)
        {
            rig.isKinematic = true;
            Firework.SetActive(true);
            fire = true;
            retime = 0f;
        }
    }
}
