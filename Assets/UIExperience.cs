using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIExperience : MonoBehaviour
{

    public TextMeshProUGUI LevelUp;
    public TextMeshProUGUI LevelUp2;
    public Slider slider;
    public Slider slider2;
    // public float Exp = 100;
    public int level = 1;
    public int StarCount = 0;


    public void UpdateValue()
    {
        slider.value = UiManager.instance.Exp;
        slider2.value = UiManager.instance.Exp;

        // 이전 경험치와 현재 경험치를 비교하여 레벨업 텍스트 업데이트
        if (UiManager.instance.Exp <= slider.minValue)
        {
            level++;
            LevelUp.text = "캠핑 레벨 : " + (level);

            LevelUp2.text = "캠핑 레벨 : " + (level);
            UiManager.instance.Exp = 100;
        }
    }


    private void Update()
    {
        if (slider != null)
        {
            slider.value = UiManager.instance.Exp;
            slider2.value = UiManager.instance.Exp;

            // 이전 경험치와 현재 경험치를 비교하여 레벨업 텍스트 업데이트
            if (UiManager.instance.Exp <= slider.minValue)
            {
                level++;
                LevelUp.text = "캠핑 레벨 : " + (level);

                LevelUp2.text = "캠핑 레벨 : " + (level);
                UiManager.instance.Exp = 100;




            }

        }
    }
}
