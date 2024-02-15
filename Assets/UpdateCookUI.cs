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
       
        Debug.Log("된거야?");
        UiManager.instance.CookingTimer.cookingStarted = true;
            // 게임 오브젝트를 활성화
        updateObject.SetActive(true);
        
    }
    public void OffUpdate()
    {
       updateObject.SetActive(false);
      
    }
}
