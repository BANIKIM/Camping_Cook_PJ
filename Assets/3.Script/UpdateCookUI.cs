using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // ��������Ʈ �迭 ����
    
    public Image tablet2;
   
    public TextMeshProUGUI updatetext2;
    public Dish dish;
    public UI_sound uI_Sound;
  
    // public string[] CookName; // �丮�� �迭 ����
    public Cooking_Type[] CookTypes; // enum�� ��Ī�Ǵ� �丮 Ÿ�� �迭 ����

    public void OpenUpdate(int i)
    {
        if (UiManager.instance.isCookingStarted)
        {
            return;
        }

        UiManager.instance.isCookingStarted = true; // isCookingStarted�� ���� ����
        UiManager.instance._cookIdx = i;
        dish.onech = false;
       
        if (i >= 0 && i < sprites.Length && i < CookTypes.Length) // ��ȿ�� �ε��� �������� Ȯ��
        {
           
            tablet2.sprite = sprites[i];

            Cooking_Type cookType = CookTypes[i];
          
            updatetext2.text = cookType.ToString();
        }
        dish.transform.position = UiManager.instance.dishSpawnPoint.transform.position;
        CookManager.instance.Spawn(i); // Spawn �޼��� ȣ��
        uI_Sound.StartBtn();
        GameManager.instance.ResetToolsPos();
    }
    public void OffUpdate()
    {
        UiManager.instance.CookingTimer.StopCooking();
         
    }

   
}