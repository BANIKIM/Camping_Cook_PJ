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

    private float startTime;
    private float FireTime = 0f;
    private float fireDuration = 5f;
    private bool OnFire = false;

    private float lastHPDecreaseTime; // 마지막 HP 감소 시간
    private float hpDecreaseInterval = 60f; // HP 감소 간격 (1분)

    private void Start()
    {
        startTime = Time.time;
        // fire_state = Fire_State.Default;
    }

    private void Awake()
    {
        // 캠프파이어 오브젝트를 태그로 찾아 변수에 저장
        // 캠프파이어 오브젝트가 가지고 있는 CampFire 스크립트 컴포넌트를 가져옴
      
        CampfireObj = GameObject.FindGameObjectWithTag(campfireTag);
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
           
            if (!campFire.Camfire_1.activeSelf) // 이미 활성화되어 있지 않은 경우에만 실행
            {
                campFire.Camfire_1.SetActive(true);
            }

        }
        if (Time.time - lastHPDecreaseTime >= hpDecreaseInterval)
        {
            // 1분이 지났으므로 HP 감소
            campFire.HP--;
            lastHPDecreaseTime = Time.time; // 마지막 HP 감소 시간 업데이트

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, campFire.expRange);
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Hand"))
                {
                    campFire.Exp += 10;
                    Debug.Log(campFire.Exp);
                  
                }
            }

            // 5분이 지난 경우
            if (Time.time - startTime >= 60f) // 
            {
                finishedfirewood1.SetActive(false);
                finishedfirewood2.SetActive(true);

            }
            // 10분이 지난 경우
            if (Time.time - startTime >= 120f) // 600초는 10분을 의미합니다
            {
                finishedfirewood2.SetActive(false);
                finishedfirewood3.SetActive(true);

            }

        }

        if (OnFire && campFire.HP > 0 && campFire.HP <= 30)
        {
            campFire.Camfire_1.SetActive(true);
            campFire.Camfire_2.SetActive(false);

        }
        else if (OnFire && campFire.HP > 30 && campFire.HP <= 60)
        {
            campFire.Camfire_1.SetActive(false);
            campFire.Camfire_2.SetActive(true);

        }
        else if (OnFire && campFire.HP <= 0)
        {
            campFire.Camfire_1.SetActive(false);
            campFire.Camfire_2.SetActive(false);
            Destroy(finishedfirewood3);
        }


    }
 


    /*  public void ChangeFireState(Fire_State startstate)
      {
          if (fire_state.Equals(startstate)) return;

          OnExit();

          fire_state = startstate;
          OnEnter();
      }

      private void TimeCheck()
      {
          timecheck_temp = TimeCheck_Co();
          StartCoroutine(timecheck_temp);

      }

      IEnumerator TimeCheck_Co()
      {
          yield return new WaitForSeconds(60f);

          campFire.HP--;

          yield return null;

      }*/


    /*    public void OnEnter()
        {
            // 오브젝트 SetActive true
            //finishedfirewoods[(int)fire_state].SetActive(true);
            TimeCheck();
            switch (fire_state)
            {
                case Fire_State.Default:
                    break;
                case Fire_State.Campfire_1:
                    break;
                case Fire_State.Campfire_2:
                    break;
                default:
                    break;
            }
        }

        public void OnUpdate()
        {
            // 시간 재기
            if (campFire.HP <= 30)
            {
                switch (fire_state)
                {
                    case Fire_State.Default:
                        break;
                    case Fire_State.Campfire_1:
                        break;
                    case Fire_State.Campfire_2:
                        break;
                    default:
                        break;
                }
            }
        }

        public void OnExit()
        {
            // 오브젝트 SetActive false    
            //finishedfirewoods[(int)fire_state].SetActive(false);
            switch (fire_state)
            {
                case Fire_State.Default:
                    break;
                case Fire_State.Campfire_1:
                    break;
                case Fire_State.Campfire_2:
                    break;
                default:
                    break;
            }
        }*/
}
