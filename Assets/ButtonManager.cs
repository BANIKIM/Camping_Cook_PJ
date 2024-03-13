using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // �ؽ�Ʈ ����
    public Text displayText;

    // ��ư�� Ŭ������ �� ȣ��� �޼���
    public void OnButtonClick(string number)
    {
        // Ŭ���� ��ư�� ���ڸ� �ؽ�Ʈ�� �߰�
        displayText.text += number;
    }

    public void ClearText()
    {
        displayText.text = "";
    }
}
