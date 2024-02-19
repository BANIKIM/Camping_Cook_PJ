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
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI timertext2;
    // public string[] CookName; // �丮�� �迭 ����
    public CookType[] CookTypes; // enum�� ��Ī�Ǵ� �丮 Ÿ�� �迭 ����
    public bool isCookingStarted = false;
    public int num;

    [SerializeField]
    private GameObject updateObject;
    [SerializeField]
    private GameObject updateObject2;




    public void OpenUpdate(int i)
    {

       UiManager.instance.CookingTimer.cookingStarted = true;
        num = i;

        if (i >= 0 && i < sprites.Length) // ��ȿ�� �ε��� �������� Ȯ��
    {
            tablet.sprite = sprites[i]; // �ε����� �ش��ϴ� ��������Ʈ�� �̹����� �Ҵ�
            tablet2.sprite = sprites[i];
            if (i >= 0 && i < CookTypes.Length) // �丮�� �迭�� ��ȿ�� �ε����� �ִ��� Ȯ��
            {
                CookType cookType = CookTypes[i];
                timertext.text = cookType.ToString();  // �ε����� �ش��ϴ� �丮���� �ؽ�Ʈ�� �Ҵ�
                timertext2.text = cookType.ToString();
            }
        }
         updateObject.SetActive(true);
        updateObject2.SetActive(true);
    }
    public void OffUpdate()
    {
        UiManager.instance.CookingTimer.StopCooking();
       
        updateObject.SetActive(false);
    }

   
}
