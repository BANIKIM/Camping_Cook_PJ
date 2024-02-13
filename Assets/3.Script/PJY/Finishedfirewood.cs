using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishedfirewood : MonoBehaviour
{
    /*    public enum Fire_State
     {
         Default = 0,
         Campfire_1,
         Campfire_2,
     }*/

    //public Fire_State fire_state { get; private set; }

    public GameObject CampfireObj;
    public GameObject finishedfirewood1;
    public GameObject finishedfirewood2;
    public GameObject finishedfirewood3;


    public string campfireTag = "Campfire";
    [SerializeField]
    private CampFire campFire;




    // private IEnumerator timecheck_temp;

    public float B_Time =0f;
    public float FireTime = 0f;
    public float fireDuration = 5f;
    private bool OnFire = false;

    private float lastHPDecreaseTime; // 마지막 HP 감소 시간
    private float hpDecreaseInterval = 60f; // HP 감소 간격 (1분)

    private void Start()
    {
        // startTime = Time.time;
        // fire_state = Fire_State.Default;
    }

    private void Awake()
    {
        // 캠프파이어 오브젝트를 태그로 찾아 변수에 저장
        // 캠프파이어 오브젝트가 가지고 있는 CampFire 스크립트 컴포넌트를 가져옴

        CampfireObj = GameObject.FindGameObjectWithTag(campfireTag);
        campFire = CampfireObj.GetComponent<CampFire>();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            
            FireTime += Time.deltaTime;
            Debug.Log("불" + FireTime);
            // 불에 닿아 있는 동안 매 프레임마다 시간을 체크하여 5초 이상이면 불을 붙입니다.
            if (FireTime > fireDuration)
            {
                if (!OnFire) // 불이 이미 붙어 있지 않은 경우에만 실행
                {
                    OnFire = true;
                }
            }
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            FireTime = 0f; // 불이 붙지 않았으므로 FireTime을 초기화
            Debug.Log("0으로 초기화");
        }
    }
    private void Update()
    {
        StartFire();
        if (OnFire) B_Time += Time.deltaTime;
    }
    private void StartFire()
    {
        if (OnFire)
        {
            // 불이 5초 이상으로 지속되었을 때만 실행됩니다.
            if (FireTime > fireDuration)
            {
                if (!campFire.Camfire_1.activeSelf) // 이미 활성화되어 있지 않은 경우에만 실행
                {
                    campFire.Camfire_1.SetActive(true);
                }
            }

            if (B_Time >= hpDecreaseInterval)
            {
                // 1분이 지났으므로 HP 감소
                campFire.HP--;
                B_Time = 0f; // 마지막 HP 감소 시간 업데이트

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, campFire.expRange);
                foreach (Collider collider in hitColliders)
                {
                    if (collider.CompareTag("Hand"))
                    {
                        campFire.Exp += 10;
                        Debug.Log(campFire.Exp);
                    }
                }

/*                // 5분이 지난 경우
                if (campFire.HP>=60) // 
                {
                
                }
                // 10분이 지난 경우
                if (campFire.HP == 30) // 600초는 10분을 의미합니다
                {
    
                }*/
            }

            if (campFire.HP > 0 && campFire.HP <= 30)
            {
                campFire.Camfire_1.SetActive(true);
                campFire.Camfire_2.SetActive(false);
                finishedfirewood2.SetActive(false);
                finishedfirewood3.SetActive(true);

            }
            else if (campFire.HP > 30 && campFire.HP <= 60)
            {
              
                campFire.Camfire_1.SetActive(false);
                campFire.Camfire_2.SetActive(true);
                finishedfirewood1.SetActive(false);
                finishedfirewood2.SetActive(true);
            }
            else if (campFire.HP <= 0)
            {
                campFire.Camfire_1.SetActive(false);
                campFire.Camfire_2.SetActive(false);
                Destroy(finishedfirewood3);
            }
        }
    }


}
