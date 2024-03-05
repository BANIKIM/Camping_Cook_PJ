using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecond; //���� ������ 100�ʴ� ���ǿ��� 1�� 

    private bool isNight = false;
    [SerializeField] private float fogDensityCal; // ������ ����
    [SerializeField] private float nightFogDensity; // �� ������ fog �е� 
    private float dayFogDensity; // �� ������  fog �е� 
    private float currentFogDensity; // ��� 

    // ���ο� Skybox ���׸���
    public Material daySkyboxMaterial;
    public Material nightSkyboxMaterial;

    private void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
          RenderSettings.skybox = daySkyboxMaterial; // ������ �� ���� �ش��ϴ� Skybox�� ����
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

                // �㿡 Skybox ���׸��� ����
               RenderSettings.skybox = nightSkyboxMaterial;
            }

        }
        else
        {   //���� ���
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCal * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;

                // ���� Skybox ���׸��� ����
                RenderSettings.skybox = daySkyboxMaterial;
               
            }
        }
      
    }

}
