using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // 스프라이트 배열 선언
    
    public Image tablet2;
   
    public TextMeshProUGUI updatetext2;
    public Dish dish;
    public UI_sound uI_Sound;
  
    // public string[] CookName; // 요리명 배열 선언
    public Cooking_Type[] CookTypes; // enum과 매칭되는 요리 타입 배열 선언

    public void OpenUpdate(int i)
    {
        if (TabletManager.instance.isCookingStarted)
        {
            return;
        }

        TabletManager.instance.isCookingStarted = true; // isCookingStarted를 먼저 변경
        TabletManager.instance._cookIdx = i;
        dish.onech = false;
       
        if (i >= 0 && i < sprites.Length && i < CookTypes.Length) // 유효한 인덱스 범위인지 확인
        {
           
            tablet2.sprite = sprites[i];

            Cooking_Type cookType = CookTypes[i];
          
            updatetext2.text = cookType.ToString();
        }
        
        CookManager.instance.Spawn(i); // Spawn 메서드 호출
        uI_Sound.StartBtn();
        GameManager.instance.ResetToolsPos();
    }
    public void OffUpdate()
    {
        TabletManager.instance.CookingTimer.StopCooking();
         
    }

   
}
