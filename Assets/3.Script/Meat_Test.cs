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
        if (renderer == null) Debug.Log("매쉬랜더 못찾음");
    }

    private void OnTriggerStay(Collider other)
    {
        if(transform.gameObject.CompareTag("Down"))
        {
            time += Time.deltaTime;
            Debug.Log("밑이 구워진다.");
            if(time> time_limit)
            {
                Material[] materials = renderer.materials;
                materials[0] = tanmat; // 원하는 매터리얼로 변경
                renderer.materials = materials; // 변경된 매터리얼 적용
            }
        }
        if (transform.gameObject.CompareTag("Up"))
        {
            time += Time.deltaTime;
            Debug.Log("위가 구워진다.");
            if (time > time_limit)
            {
                Material[] materials = renderer.materials;
                materials[0] = tanmat; // 원하는 매터리얼로 변경
                renderer.materials = materials; // 변경된 매터리얼 적용
            }
        }
    }
}
