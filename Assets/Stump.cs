using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    public GameObject woodPrefab;

    public void SpawnWoodPrefab()
    {
        // 스크립트가 붙은 오브젝트의 위치에 프리팹 생성
        Instantiate(woodPrefab, transform.position, Quaternion.identity);
    }
}
