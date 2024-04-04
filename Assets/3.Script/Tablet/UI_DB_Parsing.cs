using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UI_DB_Parsing : MonoBehaviour
{
    public enum TextType
    {
        None,
        Cook,
        Campfire
    }
    public TextType textType;
    public GoogleSheetManager google;
    public bool a = false;
    public bool b = false;
    public string number;

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            Find_cook_DB();
            a = false;
        }

        if (b)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(google.returnlist[i]) ;
            }
            b = false;
        }
    }
    //DB 값가져오기
    public void Find_cook_DB()
    {
        google.GetDB(number, 3);
    }
}
