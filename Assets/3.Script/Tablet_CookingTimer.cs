using Mirror.Examples.Basic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tablet_CookingTimer : MonoBehaviour
{
    private IEnumerator _cookingTimer_Temp;
    private IEnumerator _challengeTimer_Temp;
    public TextMeshProUGUI[] _cookTimerText;
    public TextMeshProUGUI _homeTimerText;
    public Color[] _colors;

    public void OnCookingTimer(bool isStart, int idx)
    {
        _cookingTimer_Temp = isStart ? StartCookingTimer_Co(idx) : StopCookingTimer_Co(idx);
        StartCoroutine(_cookingTimer_Temp);
    }

    private IEnumerator StartCookingTimer_Co(int idx)
    {
        float currentTime = 0;
        while (GameManager.instance.isCookingStart && idx.Equals(GameManager.instance._cookIdx))
        {
            currentTime += Time.deltaTime;

            float seconds = (int)(currentTime % 60);
            float minutes = (int)(currentTime / 60);

            _cookTimerText[idx].text = string.Format("{0:00} : {1:00}", minutes, seconds);
            _homeTimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            yield return null;
        }
    }

    private IEnumerator StopCookingTimer_Co(int idx)
    {
        _cookTimerText[idx].transform.parent.GetComponent<Image>().color = _colors[0];
        _cookTimerText[idx].text = "요리 시작";
        _homeTimerText.text = "00 : 00";
        yield return null;
    }

    public void ChallengeTimer(float seconds)
    {
        _challengeTimer_Temp = ChallengeTimer_Co(seconds);
        StartCoroutine(_challengeTimer_Temp);
    }

    private IEnumerator ChallengeTimer_Co(float seconds)
    {
        float currentTime = 60f;

        _cookTimerText[GameManager.instance._cookIdx].
            transform.parent.GetComponent<Image>().color = _colors[1];

        while (GameManager.instance.isCookingStart && currentTime > 0)
        {
            currentTime -= Time.fixedDeltaTime;
            _cookTimerText[GameManager.instance._cookIdx].text =
                string.Format("{0:00} : {1:00}", (int)currentTime / 60, (int)currentTime % 60);
            yield return new WaitForFixedUpdate();
        }
        GameManager.instance.StopCooking();
    }

}
