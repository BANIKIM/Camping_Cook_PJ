using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishedfirewood : MonoBehaviour
{


    public GameObject CampfireObj;
    public string campfireTag = "Campfire";
    [SerializeField]
    private CampFire campFire;

    [SerializeField]
    private GameObject uI_DB_ParsingObj;

    [SerializeField]
    private UI_DB_Parsing uI_DB_Parsing;



    public float B_Time =0f;
    public float FireTime = 0f;  //닿았을때 처음시간 
    public float fireDuration = 2f; // 화재발생시간 
    private bool OnFire = false; //불이 붙었는지 여부 bool값

    private float hpDecreaseInterval = 60f; // HP 감소 간격 (1분)

   
    private void Awake()
    {
        // 캠프파이어 오브젝트를 태그로 찾아 변수에 저장
        // 캠프파이어 오브젝트가 가지고 있는 CampFire 스크립트 컴포넌트를 가져옴
        uI_DB_ParsingObj = GameObject.FindGameObjectWithTag("UIManager");
        uI_DB_Parsing = uI_DB_ParsingObj.GetComponent<UI_DB_Parsing>();
        CampfireObj = GameObject.FindGameObjectWithTag(campfireTag);
        campFire = CampfireObj.GetComponent<CampFire>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            
            FireTime += Time.deltaTime;
           
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
            
        }
    }
    private void Update()
    {
        StartFire();
        if (OnFire) B_Time += Time.deltaTime;
    }


    //불이 5초이상 닿았을 때 불을 붙이고 장작의 HP를 감소시키며 HP의 따른 불의 상태변화, 플레이어가 주위에 있다면 경험치 적용
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
                    if (collider.CompareTag("Player"))
                    {
                        GameManager.instance.CampingExpCheck(10);//경험치 추가
                       
                        uI_DB_Parsing.textType = UI_DB_Parsing.TextType.Campfire;
                        uI_DB_Parsing.number = "1";
                        uI_DB_Parsing.a = true;

                    }
                }
            }

            if (campFire.HP > 0 && campFire.HP <= 30)
            {
                campFire.Camfire_1.SetActive(true);
                campFire.Camfire_2.SetActive(false);
           

            }
            else if (campFire.HP > 30 && campFire.HP <= 60)
            {
              
                campFire.Camfire_1.SetActive(false);
                campFire.Camfire_2.SetActive(true);
              
            }
            else if (campFire.HP <= 0)
            {
                campFire.Camfire_1.SetActive(false);
                campFire.Camfire_2.SetActive(false);
                
            }
        }
    }


}
