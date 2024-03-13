using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishedfirewood : MonoBehaviour
{


    public GameObject CampfireObj;
    public GameObject finishedfirewood1;
    public GameObject finishedfirewood2;
    public GameObject finishedfirewood3;


    public string campfireTag = "Campfire";
    [SerializeField]
    private CampFire campFire;

    [SerializeField]
    private GameObject uI_DB_ParsingObj;

    [SerializeField]
    private UI_DB_Parsing uI_DB_Parsing;



    public float B_Time =0f;
    public float FireTime = 0f;
    public float fireDuration = 2f;
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
                    if (collider.CompareTag("Player"))
                    {
                        GameManager.instance.CampingExpCheck(10);//����ġ �߰�
                       
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
