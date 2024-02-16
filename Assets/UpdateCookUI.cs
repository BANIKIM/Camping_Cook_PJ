using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum CookType
{
    마쉬멜로우=0,
    비프스튜=1,
    꼬치플래터=2,
    스테이크=3,
    연어스테이크=4
}


public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // 스프라이트 배열 선언
    public Image tablet;
    public Image tablet2;
    public TextMeshProUGUI timertext;
   // public string[] CookName; // 요리명 배열 선언
    public CookType[] CookTypes; // enum과 매칭되는 요리 타입 배열 선언
    public bool isCookingStarted = false;
    public int num;

    [SerializeField]
    private GameObject updateObject;

 

    public void OpenUpdate(int i)
    {

       UiManager.instance.CookingTimer.cookingStarted = true;
        num = i;

        if (i >= 0 && i < sprites.Length) // 유효한 인덱스 범위인지 확인
    {
            tablet.sprite = sprites[i]; // 인덱스에 해당하는 스프라이트를 이미지에 할당
            if (i >= 0 && i < CookTypes.Length) // 요리명 배열에 유효한 인덱스가 있는지 확인
            {
                CookType cookType = CookTypes[i];
                timertext.text = cookType.ToString();  // 인덱스에 해당하는 요리명을 텍스트에 할당
            }
        }
         updateObject.SetActive(true);
    }
    public void OffUpdate()
    {
        UiManager.instance.CookingTimer.StopCooking();
       
        updateObject.SetActive(false);
    }

   
}
