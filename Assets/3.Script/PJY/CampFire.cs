using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public GameObject FirewoodPrefab;
    public GameObject Group;

    public GameObject SpawnPosition;
    public GameObject Camfire_1; //��ȭ 1�ܰ�
    public GameObject Camfire_2; //��ȭ 2�ܰ�

    public int HP = 0;
    public int maxHP = 60;

    public float Exp = 100;
    public float expRange = 3f;

    public int maxFirewoodCount = 6; // �¿� �¿� �¿� 3�ܳ��̷� ������ �ױ� ���ؼ��� �� 18���� Firewood�� �ʿ�


    public float yOffset = 0.2f; // ���� ���� ���� Y ������
    public float xOffset = 1.0f; // ������ ���� ���� X ������
    public int rotationInterval = 1; // �����̼��� ������ ���� (1������ ����)



    private List<GameObject> firewoodList = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Firewood") && firewoodList.Count < maxFirewoodCount)
        {
            if (HP < maxHP)
            {
                Destroy(other.gameObject);
            }

            ArrangeSingleFirewood();
        }

    }


    private void ArrangeSingleFirewood()
    {
        if (FirewoodPrefab != null && HP < maxHP && SpawnPosition != null)
        {
            // �¿� �¿� �¿� 3�� ���̷� ������ �ױ� ���� �� ���̾ ���� ������ ���
            int layerCount = 2;
            int firewoodPerLayer = maxFirewoodCount / layerCount;

            float newY = SpawnPosition.transform.position.y + yOffset * (firewoodList.Count / firewoodPerLayer); // ���̾�� ���� �ױ�
            float newX = SpawnPosition.transform.position.x+0.2f - xOffset * (firewoodList.Count % firewoodPerLayer); // �� ���̾�� ������ �ױ�

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

            GameObject newFirewood = Instantiate(FirewoodPrefab, new Vector3(newX, newY+0.1f, SpawnPosition.transform.position.z), rotation);

            newFirewood.transform.parent = transform;

            firewoodList.Add(newFirewood);

            int fillAmount = Mathf.Min(10, maxHP - HP);
            HP += fillAmount;

            // Group �������� �������� �ʴ� ��쿡�� ���ο� �׷� ����
            if (firewoodList.Count >= maxFirewoodCount)
            {
                foreach (GameObject firewood in firewoodList)
                {
                    Destroy(firewood);
                }

                firewoodList.Clear();

                if (GameObject.FindGameObjectsWithTag("Group").Length == 0)
                {
                    Instantiate(Group, SpawnPosition.transform.position, Quaternion.identity);
                }
                
            }
        }
    }




}
