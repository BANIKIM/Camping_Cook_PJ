using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrilledSystem : MonoBehaviour
{
    // 레시피 때 점수 추가
    // 사운드 추가

    private new MeshRenderer renderer;
    public Material Cooked_mat;
    public Material Burnt_mat;

    [SerializeField] private TMP_Text text; 

    public float time;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        if (renderer == null) Debug.Log("매쉬랜더 못찾음");
    }

    private void OnTriggerStay(Collider other)
    {
        if (transform.gameObject.CompareTag("DownMeat"))
        {
            time += Time.deltaTime;
            Debug.Log("밑이 구워진다.");

            if (time >= 8)
            {
                Material[] materials = renderer.materials;
                materials[0] = Cooked_mat; // 원하는 매터리얼로 변경
                renderer.materials = materials; // 변경된 매터리얼 적용
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
            Debug.Log("위가 구워진다.");
           
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




