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

    private float lastHPDecreaseTime; // ������ HP ���� �ð�
    private float hpDecreaseInterval = 60f; // HP ���� ���� (1��)

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
            if (!campFire.CampfireObj.activeSelf) // �̹� Ȱ��ȭ�Ǿ� ���� ���� ��쿡�� ����
            {
                campFire.CampfireObj.SetActive(true);
            }

        }
        // ���� �ð��� ������ HP ���� �ð����� 1�� �̻� �������� Ȯ��
        if (Time.time - lastHPDecreaseTime >= hpDecreaseInterval)
        {
            // 1���� �������Ƿ� HP ����
            campFire.HP--;
            lastHPDecreaseTime = Time.time; // ������ HP ���� �ð� ������Ʈ
        }

        // ���� ���� ���¿��� HP�� 0 ������ ���
        if (OnFire && campFire.HP<= 0)
        {
            campFire.CampfireObj.SetActive(true);
        }
    }


}
