using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilingSystem : MonoBehaviour
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
    public bool heat = false;
    private int add_food = 0;

    private void Update()
    {
        MyInput();
        Debug.Log(add_food);

        if(add_food >= 3)
        {
            Debug.Log("재료가 다 들어감");
        }
    }
    
    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //재료 넣는 조건 바꿀 것
        {
            Pouring();
        }
        if (Input.GetKeyDown(KeyCode.W) && pour_water)
        {
            InputCarrot();
        }
        if (Input.GetKeyDown(KeyCode.E) && pour_water) //재료 넣는 조건 바꿀 것
        {
            InputBeef();
        }
        if (Input.GetKeyDown(KeyCode.R) && pour_water) //재료 넣는 조건 바꿀 것
        {
            InputPotato();
        }
    }

    private void Pouring()
    {
        freshWater.SetActive(true); //물이 담김
        pour_water = true;
    }
    private void InputCarrot()
    {
        SlicedCarrot.SetActive(true);
        add_food++;
    }
    private void InputBeef()
    {
        SlicedBeef.SetActive(true);
        add_food++;
    }
    private void InputPotato()
    {
        SlicedPotato.SetActive(true);
        add_food++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrillGrate"))
        {
            heat = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrillGrate"))
        {
            heat = false;
        }
    }

}
