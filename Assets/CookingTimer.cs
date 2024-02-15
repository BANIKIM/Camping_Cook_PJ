using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookingTimer : MonoBehaviour
{
    public TextMeshProUGUI timertext2;
    public TextMeshProUGUI timerText; // 타이머를 표시할 TextMeshProUGUI
    private float totalTime = 3600.0f; // 요리 시간 (초) - 1시간(60분)로 초기화

    public bool cookingStarted = false; // 요리가 시작되었는지 여부
    private float elapsedTime = 0.0f; // 경과 시간

    void Update()
    {
        // 요리가 시작되었고 아직 시간이 남아있는 경우에만 타이머 감소
        if (cookingStarted && elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;

            // 경과 시간을 분과 초로 변환
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            // 타이머 텍스트 업데이트
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timertext2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
       
        }
        // 요리가 시작되었고 전체 요리 시간이 경과한 경우
        else if (cookingStarted && elapsedTime >= totalTime)
        {
            // 타이머 텍스트를 00:00으로 설정
            timerText.text = "00:00";
            timertext2.text = "00:00";
            // 요리 중지
            StopCooking();
        }
    }

    // 요리 시작 버튼에 연결할 메서드
    public void StartCooking()
    {
        Debug.Log("눌렸냐?");
        cookingStarted = true; // 요리가 시작됨
        UiManager.instance.Update_CookUI.OpenUpdate();
    }

    // 요리 중지 메서드
    public void StopCooking()
    {
        // 요리 중지에 필요한 작업 추가
        UiManager.instance.Update_CookUI.OffUpdate();
        cookingStarted = false;
        elapsedTime = 0.0f;
        // 플레이 중인 요리 사항들을 초기화하는 작업 추가
    }
}
