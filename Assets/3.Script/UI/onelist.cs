using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class onelist : MonoBehaviour
{
    public GameObject google;
    public UI_DB_Parsing dB_Parsing;
    public GoogleSheetManager googlesheet;
    public TextMeshProUGUI textOnelist;
    public TextMeshProUGUI textOnelist2;




    private void Update()
    {
        a();
        if (googlesheet.Findnot)
        {
            if (dB_Parsing.textType==UI_DB_Parsing.TextType.Cook)
            {
                textOnelist.text = googlesheet.returnlist[1] + "요리를 만듬 경험치 " + googlesheet.returnlist[2];
                textOnelist2.text = googlesheet.returnlist[1] + "요리를 만듬 경험치 " + googlesheet.returnlist[2];
            }
            else if (dB_Parsing.textType == UI_DB_Parsing.TextType.Campfire)
            {
                textOnelist.text = "캠프파이어의 열기로 캠핑 온도를";
                textOnelist2.text = "캠프파이어의 열기로 캠핑 온도를";
            }
            
            
            
        }
    }


    public void a()
    {
        google = GameObject.FindGameObjectWithTag("UIManager");
        dB_Parsing = google.GetComponent<UI_DB_Parsing>();
        googlesheet = google.GetComponent<GoogleSheetManager>();
       
    }
}
