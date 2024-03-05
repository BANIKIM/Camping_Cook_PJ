using System.Collections;
using TMPro;
using UnityEngine;

public class Tablet_CookingTimer : MonoBehaviour
{
    private IEnumerator _cookingTimer_Temp;
    public TextMeshProUGUI _cookTimerText;
    public TextMeshProUGUI _homeTimerText;

    public void OnCookingTimer(bool isStart)
    {
        _cookingTimer_Temp = isStart ? StartCookingTimer_Co() : StopCookingTimer_Co();
        StartCoroutine(_cookingTimer_Temp);
    }

    private IEnumerator StartCookingTimer_Co()
    {
        float currentTime = 0;
        while (GameManager.instance.isCookingStart)
        {
            currentTime += Time.fixedDeltaTime;

            float seconds = (int)(currentTime % 60);
            float minutes = (int)(currentTime / 60);

            _cookTimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            _homeTimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator StopCookingTimer_Co()
    {
        _cookTimerText.text = "요리 시작";
        _homeTimerText.text = "00 : 00";
        yield return null;
    }
}
