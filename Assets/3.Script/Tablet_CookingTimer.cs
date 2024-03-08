using System.Collections;
using TMPro;
using UnityEngine;

public class Tablet_CookingTimer : MonoBehaviour
{
    private IEnumerator _cookingTimer_Temp;
    public TextMeshProUGUI[] _cookTimerText;
    public TextMeshProUGUI _homeTimerText;

    public void OnCookingTimer(bool isStart, int idx)
    {
        _cookingTimer_Temp = isStart ? StartCookingTimer_Co(idx) : StopCookingTimer_Co(idx);
        StartCoroutine(_cookingTimer_Temp);
    }

    private IEnumerator StartCookingTimer_Co(int idx)
    {
        float currentTime = 0;
        while (GameManager.instance.isCookingStart)
        {
            currentTime += Time.fixedDeltaTime;

            float seconds = (int)(currentTime % 60);
            float minutes = (int)(currentTime / 60);

            _cookTimerText[idx].text = string.Format("{0:00} : {1:00}", minutes, seconds);
            _homeTimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator StopCookingTimer_Co(int idx)
    {
        _cookTimerText[idx].text = "요리 시작";
        _homeTimerText.text = "00 : 00";
        yield return null;
    }
}
