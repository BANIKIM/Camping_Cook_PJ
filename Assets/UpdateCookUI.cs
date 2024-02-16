using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpdateCookUI : MonoBehaviour
{
    public Sprite[] sprites; // ��������Ʈ �迭 ����
    public Image image;
    public Image image2;
    public TextMeshProUGUI timertext;
    public string[] CookName; // �丮�� �迭 ����


    [SerializeField]
    private GameObject updateObject;

 public void OpenUpdate(int i)
{
    UiManager.instance.CookingTimer.cookingStarted = true;
    
    if (i >= 0 && i < sprites.Length) // ��ȿ�� �ε��� �������� Ȯ��
    {
            image.sprite = sprites[i]; // �ε����� �ش��ϴ� ��������Ʈ�� �̹����� �Ҵ�
            if (i >= 0 && i < CookName.Length) // �丮�� �迭�� ��ȿ�� �ε����� �ִ��� Ȯ��
            {
                timertext.text = CookName[i]; // �ε����� �ش��ϴ� �丮���� �ؽ�Ʈ�� �Ҵ�
            }
        }
    updateObject.SetActive(true);
}
    public void OffUpdate()
    {
       updateObject.SetActive(false);
      
    }
}
