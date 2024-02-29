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

        // ���� ����ġ�� ���� ����ġ�� ���Ͽ� ������ �ؽ�Ʈ ������Ʈ
        if (GameManager.instance._needExp <= slider2.minValue)
        {
            level++;
           

            LevelUp2.text = "ķ�� ���� : " + (level);
            GameManager.instance._needExp = 100;
        }
    }


    private void Update()
    {
        if (slider2 != null)
        {
          
            slider2.value = GameManager.instance._needExp;

            // ���� ����ġ�� ���� ����ġ�� ���Ͽ� ������ �ؽ�Ʈ ������Ʈ
            if (GameManager.instance._needExp <= slider2.minValue)
            {
                level++;
               
                LevelUp2.text = "ķ�� ���� : " + (level);
                GameManager.instance._needExp = 100;




            }

        }
    }
}
