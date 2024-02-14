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

    private float lastHPDecreaseTime; // ������ HP ���� �ð�
    private float hpDecreaseInterval = 60f; // HP ���� ���� (1��)

    private void Start()
    {
        // startTime = Time.time;
        // fire_state = Fire_State.Default;
    }

    private void Awake()
    {
        // ķ�����̾� ������Ʈ�� �±׷� ã�� ������ ����
        // ķ�����̾� ������Ʈ�� ������ �ִ� CampFire ��ũ��Ʈ ������Ʈ�� ������

        CampfireObj = GameObject.FindGameObjectWithTag(campfireTag);
        campFire = CampfireObj.GetComponent<CampFire>();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            
            FireTime += Time.deltaTime;
            Debug.Log("��" + FireTime);
            // �ҿ� ��� �ִ� ���� �� �����Ӹ��� �ð��� üũ�Ͽ� 5�� �̻��̸� ���� ���Դϴ�.
            if (FireTime > fireDuration)
            {
                if (!OnFire) // ���� �̹� �پ� ���� ���� ��쿡�� ����
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
            FireTime = 0f; // ���� ���� �ʾ����Ƿ� FireTime�� �ʱ�ȭ
            Debug.Log("0���� �ʱ�ȭ");
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
            // ���� 5�� �̻����� ���ӵǾ��� ���� ����˴ϴ�.
            if (FireTime > fireDuration)
            {
                if (!campFire.Camfire_1.activeSelf) // �̹� Ȱ��ȭ�Ǿ� ���� ���� ��쿡�� ����
                {
                    campFire.Camfire_1.SetActive(true);
                }
            }

            if (B_Time >= hpDecreaseInterval)
            {
                // 1���� �������Ƿ� HP ����
                campFire.HP--;
                B_Time = 0f; // ������ HP ���� �ð� ������Ʈ

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, campFire.expRange);
                foreach (Collider collider in hitColliders)
                {
                    if (collider.CompareTag("Hand"))
                    {
                        campFire.Exp += 10;
                        Debug.Log(campFire.Exp);
                    }
                }

/*                // 5���� ���� ���
                if (campFire.HP>=60) // 
                {
                
                }
                // 10���� ���� ���
                if (campFire.HP == 30) // 600�ʴ� 10���� �ǹ��մϴ�
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