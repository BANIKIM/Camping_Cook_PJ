using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    public GameObject woodPrefab;
    public GameObject SpawnPosition;
   

    public int maxCount = 1;

    private int currentCount = 0;

    private void Update()
    {
        // ���� ������ ������Ʈ�� ������ Ȯ���Ͽ� currentCount�� ������Ʈ�մϴ�.
        currentCount = GameObject.FindGameObjectsWithTag("Wood").Length;
    }
  
    public void SpawnWoodPrefab()
    {
        // �̹� �ִ� ���� �̻��� �������� �����Ǿ��ٸ� �� �̻� �������� ����
        if (currentCount >= maxCount)
        {
            return;
        }

        // woodPrefab�� ���� ��� ���ο� �������� ����
        if (woodPrefab == null)
        {
            Debug.LogError("woodPrefab�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }

        // ��ũ��Ʈ�� ���� ������Ʈ�� ��ġ�� ������ �����ϵ�, y���� offset�� ���� ��ġ�� ����
        Vector3 spawnPosition = SpawnPosition.transform.position;
        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f); // x�� ȸ������ 90���� ����
        Instantiate(woodPrefab, spawnPosition, rotation);

        // ������ ������ ������ ������Ŵ
        currentCount++;
    }
}
