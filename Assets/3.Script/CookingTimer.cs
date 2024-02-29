using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookingTimer : MonoBehaviour
{
   
    public TextMeshProUGUI timertext2;

   
    public TextMeshProUGUI[] timerTexts2; // Ÿ�̸Ӹ� ǥ���� TextMeshProUGUI

    private float totalTime = 3600.0f; // �丮 �ð� (��) - 1�ð�(60��)�� �ʱ�ȭ

   // public bool cookingStarted = false; // �丮�� ���۵Ǿ����� ����
    private float elapsedTime = 0.0f; // ��� �ð�

    void Update()
    {
        // �丮�� ���۵Ǿ��� ���� �ð��� �����ִ� ��쿡�� Ÿ�̸� ����
        if (UiManager.instance.isCookingStarted && elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;

           // UiManager.instance.isCookingStarted = true;
         

           
            UiManager.instance.updateObject2.SetActive(true);
           
            // ��� �ð��� �а� �ʷ� ��ȯ
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            

          

            
            timerTexts2[UiManager.instance._cookIdx].text = string.Format("{0:00}:{1:00}", minutes, seconds);

       

            timertext2.text = timerTexts2[UiManager.instance._cookIdx].text;

        }
        // �丮�� ���۵Ǿ��� ��ü �丮 �ð��� ����� ���
        else if (UiManager.instance.isCookingStarted && elapsedTime >= totalTime)
        {
            for (int i = 0; i < timerTexts2.Length; i++)
            {
                timerTexts2[i].text = "00:00";
               
            }     
            timertext2.text= "00:00";
            // �丮 ����
            StopCooking();
        }

    }

    // �丮 ���� ��ư�� ������ �޼���


    // �丮 ���� �޼���
    public void StopCooking()
    {
        // �丮 ������ �ʿ��� �۾� �߰�
        for (int i = 0; i < timerTexts2.Length; i++)
        {
           
            timerTexts2[i].text = "�丮 ����";

        }    
       
        timertext2.text = "00:00";
       // cookingStarted = false;
        UiManager.instance.isCookingStarted = false;
        
        UiManager.instance.updateObject2.SetActive(false);

        elapsedTime = 0.0f;
        // �÷��� ���� �丮 ���׵��� �ʱ�ȭ�ϴ� �۾� �߰�
    }
}