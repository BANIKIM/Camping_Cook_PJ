using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecond; //게임 세계의 100초는 현실에서 1초 

    private bool isNight = false;
    [SerializeField] private float fogDensityCal; // 증감량 비율
    [SerializeField] private float nightFogDensity; // 밤 상태의 fog 밀도 
    private float dayFogDensity; // 낮 상태의  fog 밀도 
    private float currentFogDensity; // 계산 

    // 새로운 Skybox 머테리얼
    public Material daySkyboxMaterial;
    public Material nightSkyboxMaterial;

    private void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
          RenderSettings.skybox = daySkyboxMaterial; // 시작할 때 낮에 해당하는 Skybox로 설정
    }
    private void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecond * Time.deltaTime);
        if (transform.eulerAngles.x >= 170)
        {
            isNight = true;
        }
        else if (transform.eulerAngles.x <= 10)
        {
            isNight = false;
        }

        if (isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityCal * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;

                // 밤에 Skybox 머테리얼 변경
               RenderSettings.skybox = nightSkyboxMaterial;
            }

        }
        else
        {   //낮이 경우
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCal * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;

                // 낮에 Skybox 머테리얼 변경
                RenderSettings.skybox = daySkyboxMaterial;
               
            }
        }
      
    }

}
