using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    public GameObject woodPrefab;

    public void SpawnWoodPrefab()
    {
        // ��ũ��Ʈ�� ���� ������Ʈ�� ��ġ�� ������ ����
        Instantiate(woodPrefab, transform.position, Quaternion.identity);
    }
}
