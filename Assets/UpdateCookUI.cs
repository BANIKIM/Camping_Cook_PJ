using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateCookUI : MonoBehaviour
{
   

    [SerializeField]
    private GameObject updateObject;

    public void OpenUpdate()
    {
       
        Debug.Log("�Ȱž�?");
        UiManager.instance.CookingTimer.cookingStarted = true;
            // ���� ������Ʈ�� Ȱ��ȭ
        updateObject.SetActive(true);
        
    }
    public void OffUpdate()
    {
       updateObject.SetActive(false);
      
    }
}
