using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firecracker_launch : MonoBehaviour
{
    public GameObject firecracker;
    public Transform fire;
    public float time;
    public int rittime;
    private void Start()
    {
        rittime = Random.Range(1, 3);
    }
    void Update()
    {
        if(transform.GetComponentInParent<Firework_firing>().firing)
        {
            time += Time.deltaTime;
            if(rittime<time)
            {
                Instantiate(firecracker, fire);
                time = 0;
            }
                 
        }
    }



}
