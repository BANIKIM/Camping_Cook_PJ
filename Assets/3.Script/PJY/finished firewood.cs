using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishedfirewood : MonoBehaviour
{
    public GameObject CampfireObj;
    public GameObject finishedfirewood1;
    public GameObject finishedfirewood2;
    public GameObject finishedfirewood3;

    public string campfireTag = "Campfire";
    [SerializeField]
    private CampFire campFire;

    private float startTime;
    private float FireTime = 0f;
    private float fireDuration = 5f;
    private bool OnFire = false;

    private float lastHPDecreaseTime; // ������ HP ���� �ð�
    private float hpDecreaseInterval = 60f; // HP ���� ���� (1��)

    private void Start()
    {
        startTime = Time.time;
    }

    private void Awake()
    {
        // ķ�����̾� ������Ʈ�� �±׷� ã�� ������ ����
        CampfireObj = GameObject.FindGameObjectWithTag(campfireTag);

        // ķ�����̾� ������Ʈ�� ������ �ִ� CampFire ��ũ��Ʈ ������Ʈ�� ������
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

            // 5���� ���� ���
            if (Time.time - startTime >= 300f) // 
            {
                finishedfirewood1.SetActive(false); 
                finishedfirewood2.SetActive(true);
                
            }
            // 10���� ���� ���
            if (Time.time - startTime >= 600f) // 600�ʴ� 10���� �ǹ��մϴ�
            {
                finishedfirewood2.SetActive(false); 
                finishedfirewood3.SetActive(true);
               
            }
            
        }

        if (OnFire&&campFire.HP>0&&campFire.HP<=30)
        {
            campFire.Camfire_1.SetActive(true);
            campFire.Camfire_2.SetActive(false);
          
        }
        else if (OnFire&&campFire.HP>30&&campFire.HP<=60)
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


}
