using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpUI : MonoBehaviour
{
    [SerializeField] private CampFire campFire;
    public TextMeshProUGUI LevelUp;
    public TextMeshProUGUI LevelUp2;
    public Slider slider;
    public Slider slider2;
    public  int level=1;

    private void Update()
    {
        if (campFire != null && slider != null)
        {
            slider.value = campFire.Exp;
            slider2.value = campFire.Exp;

            // 이전 경험치와 현재 경험치를 비교하여 레벨업 텍스트 업데이트
            if (campFire.Exp <= slider.minValue)
            {
                level++;
                LevelUp.text = "캠핑 레벨 : " + (level);
               
                LevelUp2.text= "캠핑 레벨 : " + (level);
                campFire.Exp = 100;
               
            }

        }
    }
}
