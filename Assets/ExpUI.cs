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

            // ���� ����ġ�� ���� ����ġ�� ���Ͽ� ������ �ؽ�Ʈ ������Ʈ
            if (Exp <= slider.minValue)
            {
                level++;
                LevelUp.text = "ķ�� ���� : " + (level);
               
                LevelUp2.text= "ķ�� ���� : " + (level);
                Exp = 100;

         


            }

        }
    }
}
