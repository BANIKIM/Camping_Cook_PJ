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
        // System.StringSplitOptions.RemoveEmptyEntries ���� ���ڿ� ����
        bool notFind = false; // ã�Ҵ��� �� ã�Ҵ��� Ȯ��
        for (int i = 0; i < stringList.Length; i++)
        {
            //Debug.Log(stringList[i]);
            if (stringList[i].Trim() == recipenum)
            {
                notFind = true;
                for (int i1 = i; i1 < (i + 7); i1++) //���� ������ŭ�� ����Ѵ�.
                {
                    Debug.Log(stringList[i1]);
                }
                break;
            }
        }
        if (!notFind) Debug.Log("������ ã�� ����");
    }
}
