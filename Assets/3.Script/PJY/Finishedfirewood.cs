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

    private float lastHPDecreaseTime; // ������ HP ���� �ð�
    private float hpDecreaseInterval = 60f; // HP ���� ���� (1��)

    private void Start()
    {
        startTime = Time.time;
        // fire_state = Fire_State.Default;
    }

    private void Awake()
    {
        // ķ�����̾� ������Ʈ�� �±׷� ã�� ������ ����
        // ķ�����̾� ������Ʈ�� ������ �ִ� CampFire ��ũ��Ʈ ������Ʈ�� ������
      
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
           
            if (!campFire.Camfire_1.activeSelf) // �̹� Ȱ��ȭ�Ǿ� ���� ���� ��쿡�� ����
            {
                campFire.Camfire_1.SetActive(true);
            }

        }
        if (Time.time - lastHPDecreaseTime >= hpDecreaseInterval)
        {
            // 1���� �������Ƿ� HP ����
            campFire.HP--;
            lastHPDecreaseTime = Time.time; // ������ HP ���� �ð� ������Ʈ

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, campFire.expRange);
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag("Hand"))
                {
                    campFire.Exp += 10;
                    Debug.Log(campFire.Exp);
                  
                }
            }

            // 5���� ���� ���
            if (Time.time - startTime >= 60f) // 
            {
                finishedfirewood1.SetActive(false);
                finishedfirewood2.SetActive(true);

            }
            // 10���� ���� ���
            if (Time.time - startTime >= 120f) // 600�ʴ� 10���� �ǹ��մϴ�
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
            // ������Ʈ SetActive true
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
            // �ð� ���
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
            // ������Ʈ SetActive false    
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
