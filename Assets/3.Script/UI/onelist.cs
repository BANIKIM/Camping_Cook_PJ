using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onelist : MonoBehaviour
{
    public GameObject google;
    public UI_DB_Parsing dB_Parsing;
    public GoogleSheetManager googlesheet;

    private void OnEnable()
    {
        a();
        if (googlesheet.Findnot)
        {
            Debug.Log(googlesheet.returnlist[1] + "�丮�� ��������ϴ�." + googlesheet.returnlist[2] + "����ġ ȹ��");
        }

    }


    public void a()
    {
        google = GameObject.FindGameObjectWithTag("UIManager");
        dB_Parsing = google.GetComponent<UI_DB_Parsing>();
        googlesheet = google.GetComponent<GoogleSheetManager>();
    }
}
