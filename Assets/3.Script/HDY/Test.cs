using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
     재료 - 소고기, 연어, 아스파라거스, 감자, 당근, 양파, 버섯, 마시멜로우
     양념 - 소금, 후추
     
     레시피 - 마시멜로우, 연어구이, 소고기스테이크, 비프스튜, 꼬치플레터
     
     마시멜로우
     식재료 - 마시멜로우
     손질 - 꽂기
     조리 - 굽기 1
     플레 - 1회용 접시에 마시멜로우

     연어구이
     식재료 - 연어, 아스파라거스
     손질 - 연어(자르기 2), 연어(양념-소금), 연어(양념-후추), 아스파라거스(자르기 1)
     조리 - 연어(굽기 2)
     플레 - 접시에 연어, 아스파라거스

     소고기 스테이크
     식재료 - 소고기, 양파
     손질 - 소고기(양념-소금), 소고기(양념-후추), 양파(자르기 2)
     조리 - 소고기(굽기 2)
     플레 - 접시에 소고기, 양파

     꼬치 플레터
     식재료 - 소고기, 양파, 버섯
     손질 - 소고기(양념-소금), 소고기(자르기 2) 양파(자르기 2), 버섯(자르기 2), 꽂기
     조리 - 굽기 2
     플레 - 접시에 꼬치

     비프스튜
     식재료 - 소고기 감자 당근
     손질 - 소고기(자르기 2), 당근(자르기 2), 양파(자르기 2)
     조리 - 끓이기
     플레 - 접시에 비프스튜
     
     */
    /*
    재료 호출 시 나온 재료들과 마지막에 접시에 담긴 재료를 비교하면 플레이팅 통과
    - 라고 혼자 생각함
    */
    public enum Ingredient
    {
        marshmallow = 0,
        beef, 
        salmon,
        asparagus,
        potato,
        carrot,
        onion,
        mushroom
    }

    public enum Cooking
    {
        cut_0 = 0, cut_1, cut_2, cut_3, 
        seasoning_s = 10, seasoning_p = 11,
        stick = 20,
        toast_1 = 30, toast_2, toast_3,
        toast_all = 40,
        boil_0 = 50, boil_1, boil_2
    }

    #region 보류
    //private Ingredient[] Grilled_Salmon = { Ingredient.salmon, Ingredient.asparagus };
    //private Cooking[] how_cook = {Cooking.cut_1, Cooking.cut_3, 
    //                              Cooking.seasoning_s, Cooking.seasoning_p,
    //                              Cooking.toast_1};

    //private void Update()
    //{
    //    Check();
    //}

    //private void Check()
    //{

    //}
    #endregion

    private void Update()
    {

    }

    //연어구이 레시피
    private void Recipe_step()
    {
        int numRows = Ingredient.GetValues(typeof(Ingredient)).Length;
        int numCols = Cooking.GetValues(typeof(Cooking)).Length;

        int[,] GrilledSalmon = new int[numRows, numCols];

        GrilledSalmon[(int)Ingredient.asparagus, (int)Cooking.cut_1] = 1;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.cut_3] = 2;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.seasoning_s] = 3;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.seasoning_p] = 4;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.toast_2] = 5;
        
    }

    private void Check_call()
    {
        //조리대에 레시피대로 재료 호출
        //예) 연어구이 - 연어, 아스파라거스
        

    }

    private void Check_plate() //접시 위의 재료 판정
    {
        //만약 접시 위의 재료가 call list의 재료와 같다면 판정 성공

    }

}
