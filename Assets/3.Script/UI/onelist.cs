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

    private void OnEnable()
    {
        a();
        if (googlesheet.Findnot)
        {
            textOnelist.text = googlesheet.returnlist[1]+ "�丮�� ���� ����ġ " +googlesheet.returnlist[2];
        }

    }


    public void a()
    {
        google = GameObject.FindGameObjectWithTag("UIManager");
        dB_Parsing = google.GetComponent<UI_DB_Parsing>();
        googlesheet = google.GetComponent<GoogleSheetManager>();
    }
}
