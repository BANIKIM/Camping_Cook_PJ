using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_sound : MonoBehaviour
{
    public AudioSource buttonClickSound1; 
    public AudioSource buttonClickSound2;

    public void PlayButtonClickSound1()
    {
        buttonClickSound1.PlayOneShot(buttonClickSound1.clip);
        Debug.Log("UI ���� �Ŵ���");
    }
    public void StartBtn()
    {
       
        buttonClickSound2.PlayOneShot(buttonClickSound2.clip);
    }


   
   
}
