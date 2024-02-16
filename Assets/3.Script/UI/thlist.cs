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
            Debug.Log(aa[0] + "요리를 만들었습니다." + aa[1] + "경험치 획득");
            Debug.Log(aa[2] + "요리를 만들었습니다." + aa[3] + "경험치 획득");
            Debug.Log(aa[4] + "요리를 만들었습니다." + aa[5] + "경험치 획득");
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
        //맨밑줄 밀어내기
        aa[2] = aa[0];
        aa[3] = aa[1];
        //두번쨰줄 밀어내기
    }
    public void a()
    {
        google = GameObject.FindGameObjectWithTag("UIManager");
        dB_Parsing = google.GetComponent<UI_DB_Parsing>();
        googlesheet = google.GetComponent<GoogleSheetManager>();
    }
}
