using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public bool saulting = false;
    public bool peppering = false;

    private void Update()
    {
        WhatSeasoning(); //�ұݰ� ���� �ѷ����ٴ� �� ��� �߰� �� ��ġ�� ����
    }

    private void WhatSeasoning()
    {
        if (saulting)
        {
            Debug.Log("�ұ�");
        }
        if (peppering)
        {
            Debug.Log("����");
        }
    }

}
