using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // 텍스트 상자
    public Text displayText;

    // 버튼을 클릭했을 때 호출될 메서드
    public void OnButtonClick(string number)
    {
        // 클릭된 버튼의 숫자를 텍스트에 추가
        displayText.text += number;
    }

    public void ClearText()
    {
        displayText.text = "";
    }
}
