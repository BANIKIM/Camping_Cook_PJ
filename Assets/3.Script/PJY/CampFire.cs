using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public GameObject FirewoodPrefab;
    public GameObject finishedfirewood;
    public GameObject CampfireObj;

    public  int HP = 10;
    public int maxHP = 60;

    public int maxFirewoodCount = 6; // �¿� �¿� �¿� 3�ܳ��̷� ������ �ױ� ���ؼ��� �� 18���� Firewood�� �ʿ�


    private float FireTime = 0f;
    private float fireDuration = 5f;
    private bool OnFire = false;

    private float lastHPDecreaseTime; // ������ HP ���� �ð�
    private float hpDecreaseInterval = 60f; // HP ���� ���� (1��)

    public float yOffset = 0.2f; // ���� ���� ���� Y ������
    public float xOffset = 1.0f; // ������ ���� ���� X ������
    public int rotationInterval = 1; // �����̼��� ������ ���� (1������ ����)

    private List<GameObject> firewoodList = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Firewood") && firewoodList.Count < maxFirewoodCount)
        {
            Destroy(other.gameObject);
            ArrangeSingleFirewood();
        }
       /* else if (other.CompareTag("Fire") && finishedfirewood != null)
        {
            OnFire = true;
            FireTime = Time.time;
        }*/

    }
/*    private void Update()
    {
        if (OnFire && Time.time - FireTime >= fireDuration)
        {
            if (finishedfirewood != null) // finishedfirewood�� ������ ����
            {
                CampfireObj.SetActive(true);
            }
        }
        // ���� �ð��� ������ HP ���� �ð����� 1�� �̻� �������� Ȯ��
        if (Time.time - lastHPDecreaseTime >= hpDecreaseInterval)
        {
            // 1���� �������Ƿ� HP ����
            HP--;
            lastHPDecreaseTime = Time.time; // ������ HP ���� �ð� ������Ʈ
        }

        // ���� ���� ���¿��� HP�� 0 ������ ���
        if (OnFire && HP <= 0)
        {
            CampfireObj.SetActive(false);
        }
    }*/

    private void ArrangeSingleFirewood()
    {
        if (FirewoodPrefab != null)
        {
            // �¿� �¿� �¿� 3�� ���̷� ������ �ױ� ���� �� ���̾ ���� ������ ���
            int layerCount = 2;
            int firewoodPerLayer = maxFirewoodCount / layerCount;

            float newY = transform.position.y + yOffset * (firewoodList.Count / firewoodPerLayer); // ���̾�� ���� �ױ�

            float newX = transform.position.x + 1f - xOffset * (firewoodList.Count % firewoodPerLayer); // �� ���̾�� ������ �ױ�

            // �����̼��� ������ ���ݿ� �°� �����̼��� �����մϴ�.
            Quaternion rotation = Quaternion.identity;
            if (firewoodList.Count % firewoodPerLayer == 0)
            {
                rotation = Quaternion.Euler(180, 0, 0); // �� ���̾��� ù ��°�� ���̴� ������ �����̼� X���� 180���� ����
            }
            else if (firewoodList.Count % firewoodPerLayer == firewoodPerLayer - 1)
            {
                rotation = Quaternion.Euler(180, 0, 0); // �� ���̾��� ���������� ���̴� ������ �����̼� X���� 180���� ����
            }

            // Instantiate a new FirewoodPrefab with the updated position and rotation
            GameObject newFirewood = Instantiate(FirewoodPrefab, new Vector3(newX, newY + 0.5f, transform.position.z), rotation);

            // Make the new firewood a child of the CampFire object
            newFirewood.transform.parent = transform;

            // Add the new firewood to the list
            firewoodList.Add(newFirewood);

            // Update HP
            HP += 10;

           
            if (firewoodList.Count >= maxFirewoodCount)
            {
              
                foreach (GameObject firewood in firewoodList)
                {
                    Destroy(firewood);
                }

              
                firewoodList.Clear();

               
                Instantiate(finishedfirewood, transform.position, Quaternion.identity);
            }
        }
    }



}
