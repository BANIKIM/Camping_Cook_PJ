using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public GameObject FirewoodPrefab;
    public GameObject Group;

    public GameObject SpawnPosition;
    public GameObject Camfire_1; //점화 1단계
    public GameObject Camfire_2; //점화 2단계

    public int HP = 0;
    public int maxHP = 60;

    public float Exp = 100;
    public float expRange = 3f;

    public int maxFirewoodCount = 6; // 좌우 좌우 좌우 3단높이로 장작을 쌓기 위해서는 총 18개의 Firewood가 필요


    public float yOffset = 0.2f; // 위로 쌓을 때의 Y 오프셋
    public float xOffset = 1.0f; // 옆으로 쌓을 때의 X 오프셋
    public int rotationInterval = 1; // 로테이션을 변경할 간격 (1개마다 변경)



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
            // 좌우 좌우 좌우 3단 높이로 장작을 쌓기 위해 각 레이어에 대한 개수를 계산
            int layerCount = 2;
            int firewoodPerLayer = maxFirewoodCount / layerCount;

            float newY = SpawnPosition.transform.position.y + yOffset * (firewoodList.Count / firewoodPerLayer); // 레이어별로 위로 쌓기
            float newX = SpawnPosition.transform.position.x+0.2f - xOffset * (firewoodList.Count % firewoodPerLayer); // 각 레이어별로 옆으로 쌓기

            // 로테이션을 변경할 간격에 맞게 로테이션을 조정합니다.
            Quaternion rotation = Quaternion.identity;
            if (firewoodList.Count % firewoodPerLayer == 0)
            {
                rotation = Quaternion.Euler(180, 0, 0); // 각 레이어의 첫 번째로 쌓이는 나무의 로테이션 X값을 180으로 설정
            }
            else if (firewoodList.Count % firewoodPerLayer == firewoodPerLayer - 1)
            {
                rotation = Quaternion.Euler(180, 0, 0); // 각 레이어의 마지막으로 쌓이는 나무의 로테이션 X값을 180으로 설정
            }

            GameObject newFirewood = Instantiate(FirewoodPrefab, new Vector3(newX, newY+0.1f, SpawnPosition.transform.position.z), rotation);

            newFirewood.transform.parent = transform;

            firewoodList.Add(newFirewood);

            int fillAmount = Mathf.Min(10, maxHP - HP);
            HP += fillAmount;

            // Group 프리팹이 존재하지 않는 경우에만 새로운 그룹 생성
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
