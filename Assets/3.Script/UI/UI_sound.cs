using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_sound : MonoBehaviour
{
    public AudioSource buttonClickSound1; 
  
    
    public void PlayButtonClickSound1()
    {
        buttonClickSound1.PlayOneShot(buttonClickSound1.clip); 
    }

   
   
}
