using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // ��������Ʈ �迭 ����
    public Image tablet;
    public Image tablet2;
    public TextMeshProUGUI updatetext;
    public TextMeshProUGUI updatetext2;
    public Dish dish;
    public AudioSource buttonClickSound;
    // public string[] CookName; // �丮�� �迭 ����
    public Cooking_Type[] CookTypes; // enum�� ��Ī�Ǵ� �丮 Ÿ�� �迭 ����

    public void OpenUpdate(int i)
    {
        if (UiManager.instance.isCookingStarted)
        {
            return;
        }

        UiManager.instance.isCookingStarted = true; // isCookingStarted�� ���� ����
        UiManager.instance.Num = i;
        dish.onech = false;
        buttonClickSound.PlayOneShot(buttonClickSound.clip);

        if (i >= 0 && i < sprites.Length && i < CookTypes.Length) // ��ȿ�� �ε��� �������� Ȯ��
        {
            tablet.sprite = sprites[i]; // �ε����� �ش��ϴ� ��������Ʈ�� �̹����� �Ҵ�
            tablet2.sprite = sprites[i];

            Cooking_Type cookType = CookTypes[i];
            updatetext.text = cookType.ToString();  // �ε����� �ش��ϴ� �丮���� �ؽ�Ʈ�� �Ҵ�
            updatetext2.text = cookType.ToString();
        }

        CookManager.instance.Spawn(i); // Spawn �޼��� ȣ��
    }
    public void OffUpdate()
    {
        UiManager.instance.CookingTimer.StopCooking();
         
    }

   
}
