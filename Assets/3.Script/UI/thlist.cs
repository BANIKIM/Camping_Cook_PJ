using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thlist : MonoBehaviour
{
    public GameObject google;
    public UI_DB_Parsing dB_Parsing;
    public GoogleSheetManager googlesheet;
    public string[] aa = new string[6];
    private void OnEnable()
    {
        a();
        if (googlesheet.thnot)
        {
    
                ch();
                one();
            
            googlesheet.thnot = false;
        }
        if(aa[0]!=null)
        {
            Debug.Log(aa[0] + "�丮�� ��������ϴ�." + aa[1] + "����ġ ȹ��");
            Debug.Log(aa[2] + "�丮�� ��������ϴ�." + aa[3] + "����ġ ȹ��");
            Debug.Log(aa[4] + "�丮�� ��������ϴ�." + aa[5] + "����ġ ȹ��");
        }
       

    }

    public void one()
    {
        aa[0] = googlesheet.returnlist[1];
        aa[1] = googlesheet.returnlist[2];
    }
    public void two()
    {
        aa[2] = googlesheet.returnlist[1];
        aa[3] = googlesheet.returnlist[2];
    }
    public void th()
    {
        aa[4] = googlesheet.returnlist[1];
        aa[5] = googlesheet.returnlist[2];
    }

    public void ch()
    {
        aa[4] = aa[2];
        aa[5] = aa[3];
        //�ǹ��� �о��
        aa[2] = aa[0];
        aa[3] = aa[1];
        //�ι����� �о��
    }
    public void a()
    {
        google = GameObject.FindGameObjectWithTag("UIManager");
        dB_Parsing = google.GetComponent<UI_DB_Parsing>();
        googlesheet = google.GetComponent<GoogleSheetManager>();
    }
}
