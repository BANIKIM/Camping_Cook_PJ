using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookingTimer : MonoBehaviour
{
    public TextMeshProUGUI timertext2;
    public TextMeshProUGUI[] timerText; // Ÿ�̸Ӹ� ǥ���� TextMeshProUGUI
    private float totalTime = 3600.0f; // �丮 �ð� (��) - 1�ð�(60��)�� �ʱ�ȭ

    public bool cookingStarted = false; // �丮�� ���۵Ǿ����� ����
    private float elapsedTime = 0.0f; // ��� �ð�

    void Update()
    {
        // �丮�� ���۵Ǿ��� ���� �ð��� �����ִ� ��쿡�� Ÿ�̸� ����
        if (cookingStarted && elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;

            // ��� �ð��� �а� �ʷ� ��ȯ
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            // Ÿ�̸� �ؽ�Ʈ ������Ʈ
            for (int i = 0; i < timerText.Length; i++)
            {
               
                    timerText[i].text = string.Format("{0:00}:{1:00}", minutes, seconds);
                    timertext2.text = timerText[i].text;
              
               
            }
        }
        // �丮�� ���۵Ǿ��� ��ü �丮 �ð��� ����� ���
        else if (cookingStarted && elapsedTime >= totalTime)
        {
            for (int i = 0; i < timerText.Length; i++)
            {
                timerText[i].text = "00:00";
            }
            timertext2.text = "00:00";
            // �丮 ����
            StopCooking();
        }
    }

    // �丮 ���� ��ư�� ������ �޼���
  

    // �丮 ���� �޼���
    public void StopCooking()
    {
        // �丮 ������ �ʿ��� �۾� �߰�
        UiManager.instance.Update_CookUI.OffUpdate();
        cookingStarted = false;
        elapsedTime = 0.0f;
        // �÷��� ���� �丮 ���׵��� �ʱ�ȭ�ϴ� �۾� �߰�
    }
}
