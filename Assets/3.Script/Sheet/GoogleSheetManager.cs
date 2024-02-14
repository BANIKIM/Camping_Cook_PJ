using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleSheetManager : MonoBehaviour
{
    public TextAsset mytext;
    public string recipenum;


    private void Start()
    {
        GetDB(recipenum);
    }

    public void GetDB(string recipenum)
    {
        string[] stringList = mytext.ToString().Split(new char[] { '\n', ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        // System.StringSplitOptions.RemoveEmptyEntries 공백 빈문자열 제거
        bool notFind = false; // 찾았는지 못 찾았는지 확인
        for (int i = 0; i < stringList.Length; i++)
        {
            //Debug.Log(stringList[i]);
            if (stringList[i].Trim() == recipenum)
            {
                notFind = true;
                for (int i1 = i; i1 < (i + 7); i1++) //열의 갯수만큼만 출력한다.
                {
                    Debug.Log(stringList[i1]);
                }
                break;
            }
        }
        if (!notFind) Debug.Log("데이터 찾지 못함");
    }
}
