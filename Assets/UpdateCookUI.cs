using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // 스프라이트 배열 선언
    public Image tablet;
    public Image tablet2;
    public TextMeshProUGUI updatetext;
    public TextMeshProUGUI updatetext2;
    // public string[] CookName; // 요리명 배열 선언
    public Cooking_Type[] CookTypes; // enum과 매칭되는 요리 타입 배열 선언
   

 

    





    public void OpenUpdate(int i)
    {
        if (UiManager.instance.isCookingStarted)
        {
            return;
        }
        UiManager.instance.Num = i;    
        UiManager.instance.CookingTimer.cookingStarted = true;
       

        if (i >= 0 && i < sprites.Length) // 유효한 인덱스 범위인지 확인
        {
            tablet.sprite = sprites[i]; // 인덱스에 해당하는 스프라이트를 이미지에 할당
            tablet2.sprite = sprites[i];
            if (i >= 0 && i < CookTypes.Length) // 요리명 배열에 유효한 인덱스가 있는지 확인
            {
                Cooking_Type cookType = CookTypes[i];
                updatetext.text = cookType.ToString();  // 인덱스에 해당하는 요리명을 텍스트에 할당
                updatetext2.text = cookType.ToString();
            }
        }
       


    }
    public void OffUpdate()
    {
        UiManager.instance.CookingTimer.StopCooking();
          

    }

   
}
