using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiling : MonoBehaviour
{
    /*
    끓이기 로직
    끓이기 단계 3 -> 0 1 2
    start 0단계
    time >= 8 -> 1단계
    time >= 10 -> 2단계
    끓이기 단계는 점수 판정에 들어감

    냄비
    냄비 + 물 (식재료가 투명화됨)
    냄비 + 물 (식재료가 나타남) + 식재료 투입 (투입할 때마다 타이머 초기화)

    맹물이거나 재료가 다 안들어가도 끓일 수 있어야 함

    물의 상태로만 끓이기 판별
    */
    
    [SerializeField] GameObject freshWater;
    [SerializeField] GameObject SlicedCarrot;
    [SerializeField] GameObject SlicedBeef;
    [SerializeField] GameObject SlicedPotato;

    private bool pour_water = false;

    public int water_HP = 0;
    public int ingred_HP = 5;
    public float All_hp = 0;

    public int boilingTime;

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //재료 넣는 조건 바꿀 것
        {
            freshWater.SetActive(true); //물이 담김
            pour_water = true;
        }

        if (pour_water)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                SlicedCarrot.SetActive(true);
                All_hp = All_hp+ ingred_HP;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SlicedBeef.SetActive(true);
                All_hp = All_hp + ingred_HP;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SlicedPotato.SetActive(true);
                All_hp = All_hp + ingred_HP;
            }
        }
        else
        {
            Debug.Log("물 없이는 재료를 넣지 못함");
        }   
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GrillGrate"))
        {
            All_hp -= Time.deltaTime;
            
            if (All_hp > 0)
            {
                Debug.Log("덜 익음");
            }
            else if(All_hp <= -10)
            {
                Debug.Log("탄 상태");

            }
            else
            {
                Debug.Log("Best Score");
            }
        }
    }
}
