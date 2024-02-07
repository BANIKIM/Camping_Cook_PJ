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

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        if(fountain) rig.AddForce(Vector3.up * 900);
        time = Random.Range(2, 4);//ÅÍÁö´Â ½Ã°£·£´ý
    }

    private void Update()
    {
        if(!fire)retime += Time.deltaTime;

        if (time < retime)
        {
            int num = Random.Range(0, Firework.Length);
            rig.isKinematic = true;
            Firework[num].SetActive(true); //·£´ýÀ¸·Î ´Ù¸¥ ÀÌÆåÆ®°¡ ÅÍÁü
            fire = true;
            retime = 0f;
            Destroy(gameObject, 8f);
        }
    }
}
