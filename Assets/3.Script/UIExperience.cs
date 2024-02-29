using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIExperience : MonoBehaviour
{

    public TextMeshProUGUI LevelUp2;
  
    public Slider slider2;
    // public float Exp = 100;
    public int level = 1;
    public int StarCount = 0;


    public void UpdateValue()
    {
       
        slider2.value = GameManager.instance._needExp;

        // 이전 경험치와 현재 경험치를 비교하여 레벨업 텍스트 업데이트
        if (GameManager.instance._needExp <= slider2.minValue)
        {
            level++;
           

            LevelUp2.text = "캠핑 레벨 : " + (level);
            GameManager.instance._needExp = 100;
        }
    }


    private void Update()
    {
        if (slider2 != null)
        {
          
            slider2.value = GameManager.instance._needExp;

            // 이전 경험치와 현재 경험치를 비교하여 레벨업 텍스트 업데이트
            if (GameManager.instance._needExp <= slider2.minValue)
            {
                level++;
               
                LevelUp2.text = "캠핑 레벨 : " + (level);
                GameManager.instance._needExp = 100;




            }

        }
    }
}
