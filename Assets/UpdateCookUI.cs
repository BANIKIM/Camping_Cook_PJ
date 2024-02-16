using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // 스프라이트 배열 선언
    public Image image;
    public Image image2;
    public TextMeshProUGUI timertext;
    public string[] CookName; // 요리명 배열 선언


    [SerializeField]
    private GameObject updateObject;

 public void OpenUpdate(int i)
{
    UiManager.instance.CookingTimer.cookingStarted = true;
    
    if (i >= 0 && i < sprites.Length) // 유효한 인덱스 범위인지 확인
    {
            image.sprite = sprites[i]; // 인덱스에 해당하는 스프라이트를 이미지에 할당
            if (i >= 0 && i < CookName.Length) // 요리명 배열에 유효한 인덱스가 있는지 확인
            {
                timertext.text = CookName[i]; // 인덱스에 해당하는 요리명을 텍스트에 할당
            }
        }
    updateObject.SetActive(true);
}
    public void OffUpdate()
    {
       updateObject.SetActive(false);
      
    }
}
