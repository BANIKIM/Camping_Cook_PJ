using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleSheetManager : MonoBehaviour
{
    public TextAsset mytext;
    public string[] returnlist;
    int a = 0;
    public bool Findnot = false;
    public bool thnot = false;

    public void GetDB(string recipenum , int limit)
    {
        string[] stringList = mytext.ToString().Split(new char[] { '\n', ',' }, System.StringSplitOptions.RemoveEmptyEntries);
        returnlist = new string[limit];
        // System.StringSplitOptions.RemoveEmptyEntries ���� ���ڿ� ����
        bool notFind = false; // ã�Ҵ��� �� ã�Ҵ��� Ȯ��
        for (int i = 0; i < stringList.Length; i++)
        {
            //Debug.Log(stringList[i]);
            if (stringList[i].Trim() == recipenum)
            {
                thnot = true;
                Findnot = true;
                notFind = true;
                for (int i1 = i; i1 < (i + limit); i1++) //���� ������ŭ�� ����Ѵ�.
                {
                    returnlist[a] = (string)stringList[i1];
                    a++;
                }
                a = 0;
                break;
            }
        }
        if (!notFind) Debug.Log("������ ã�� ����");
    }
}
