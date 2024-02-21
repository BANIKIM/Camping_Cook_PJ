using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpUI : MonoBehaviour
{
   
    public TextMeshProUGUI LevelUp;
    public TextMeshProUGUI LevelUp2;
    public Slider slider;
    public Slider slider2;
    public float Exp = 100;
    public  int level=1;
    public int StarCount=0;
  
   

    private void Update()
    {
        if (slider != null)
        {
            slider.value = Exp;
            slider2.value = Exp;

            // 이전 경험치와 현재 경험치를 비교하여 레벨업 텍스트 업데이트
            if (Exp <= slider.minValue)
            {
                level++;
                LevelUp.text = "캠핑 레벨 : " + (level);
               
                LevelUp2.text= "캠핑 레벨 : " + (level);
                Exp = 100;

         


            }

        }
    }
}
