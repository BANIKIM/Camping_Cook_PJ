using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipesUI : MonoBehaviour
{
   
   public List<Button> CookCountBtn;

    public void Cooktype()
    {
        
        UiManager.instance.CookingTimer.cookingStarted = true;
      
    }
}
