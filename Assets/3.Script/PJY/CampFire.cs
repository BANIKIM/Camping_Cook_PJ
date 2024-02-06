using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public GameObject FirewoodPrefab;
    public int maxFirewoodCount = 6; // 최대 놓을 수 있는 Firewood 개수
    public float xOffset = 1.0f;

    private List<GameObject> firewoodList = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Firewood") && firewoodList.Count < maxFirewoodCount)
        {
            Destroy(collision.gameObject);
            ArrangeSingleFirewood();
        }
    }

    private void ArrangeSingleFirewood()
    {
        if (FirewoodPrefab != null)
        {
            float newX = transform.position.x + xOffset * firewoodList.Count;

            // Instantiate a new FirewoodPrefab
            GameObject newFirewood = Instantiate(FirewoodPrefab, new Vector3(newX, transform.position.y, transform.position.z), Quaternion.identity);

            // Make the new firewood a child of the CampFire object
            newFirewood.transform.parent = transform;

            // Add the new firewood to the list
            firewoodList.Add(newFirewood);
        }
    }
}