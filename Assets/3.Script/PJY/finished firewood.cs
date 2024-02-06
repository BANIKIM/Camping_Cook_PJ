using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishedfirewood : MonoBehaviour
{
    public GameObject CampfireObj;
    public string campfireTag = "Campfire";
    [SerializeField]
    private CampFire campFire;

    private float FireTime = 0f;
    private float fireDuration = 5f;
    private bool OnFire = false;

    private float lastHPDecreaseTime; // 마지막 HP 감소 시간
    private float hpDecreaseInterval = 60f; // HP 감소 간격 (1분)

    private void Awake()
    {
        // 캠프파이어 오브젝트를 태그로 찾아 변수에 저장
        CampfireObj = GameObject.FindGameObjectWithTag(campfireTag);

        // 캠프파이어 오브젝트가 가지고 있는 CampFire 스크립트 컴포넌트를 가져옴
        campFire = CampfireObj.GetComponent<CampFire>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            OnFire = true;
            FireTime = Time.time;
        }
    }
    private void Update()
    {
        if (OnFire && Time.time - FireTime >= fireDuration)
        {
            if (!campFire.CampfireObj.activeSelf) // 이미 활성화되어 있지 않은 경우에만 실행
            {
                campFire.CampfireObj.SetActive(true);
            }

        }
        // 현재 시간이 마지막 HP 감소 시간보다 1분 이상 지났는지 확인
        if (Time.time - lastHPDecreaseTime >= hpDecreaseInterval)
        {
            // 1분이 지났으므로 HP 감소
            campFire.HP--;
            lastHPDecreaseTime = Time.time; // 마지막 HP 감소 시간 업데이트
        }

        // 불이 붙은 상태에서 HP가 0 이하인 경우
        if (OnFire && campFire.HP<= 0)
        {
            campFire.CampfireObj.SetActive(true);
        }
    }


}
