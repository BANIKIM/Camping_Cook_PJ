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

    public int maxFirewoodCount = 6; // 좌우 좌우 좌우 3단높이로 장작을 쌓기 위해서는 총 18개의 Firewood가 필요


    private float FireTime = 0f;
    private float fireDuration = 5f;
    private bool OnFire = false;

    private float lastHPDecreaseTime; // 마지막 HP 감소 시간
    private float hpDecreaseInterval = 60f; // HP 감소 간격 (1분)

    public float yOffset = 0.2f; // 위로 쌓을 때의 Y 오프셋
    public float xOffset = 1.0f; // 옆으로 쌓을 때의 X 오프셋
    public int rotationInterval = 1; // 로테이션을 변경할 간격 (1개마다 변경)

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
            if (finishedfirewood != null) // finishedfirewood가 존재할 때만
            {
                CampfireObj.SetActive(true);
            }
        }
        // 현재 시간이 마지막 HP 감소 시간보다 1분 이상 지났는지 확인
        if (Time.time - lastHPDecreaseTime >= hpDecreaseInterval)
        {
            // 1분이 지났으므로 HP 감소
            HP--;
            lastHPDecreaseTime = Time.time; // 마지막 HP 감소 시간 업데이트
        }

        // 불이 붙은 상태에서 HP가 0 이하인 경우
        if (OnFire && HP <= 0)
        {
            CampfireObj.SetActive(false);
        }
    }*/

    private void ArrangeSingleFirewood()
    {
        if (FirewoodPrefab != null)
        {
            // 좌우 좌우 좌우 3단 높이로 장작을 쌓기 위해 각 레이어에 대한 개수를 계산
            int layerCount = 2;
            int firewoodPerLayer = maxFirewoodCount / layerCount;

            float newY = transform.position.y + yOffset * (firewoodList.Count / firewoodPerLayer); // 레이어별로 위로 쌓기

            float newX = transform.position.x + 1f - xOffset * (firewoodList.Count % firewoodPerLayer); // 각 레이어별로 옆으로 쌓기

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
