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
   
    public TextMeshProUGUI textOnelist2;




    private void Update()
    {
        a();
        if (googlesheet.Findnot)
        {
            if (dB_Parsing.textType==UI_DB_Parsing.TextType.Cook)
            {
              
                textOnelist2.text = googlesheet.returnlist[1] + "�丮�� ���� ����ġ " + googlesheet.returnlist[2];
            }
            else if (dB_Parsing.textType == UI_DB_Parsing.TextType.Campfire)
            {
               
                textOnelist2.text = "ķ�����̾��� ����� ķ�� �µ��� 10 ������ϴ�.";
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
