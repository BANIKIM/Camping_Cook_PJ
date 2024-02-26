using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingredients;   // 식재료 모아져있는 프리팹

    [SerializeField] private Transform _spawnPoint;      // 스폰포인트

    public void Spawn(int idx) 
    {
       
        // Instantiate로 생성
        GameObject spawnobj =  Instantiate(_ingredients[idx], _spawnPoint.position, Quaternion.identity);

        // 상속된 오브젝트 개별로 바꿈
        for (int i = 0; i < spawnobj.transform.childCount; i++)
        {
            spawnobj.transform.GetChild(i).transform.parent = null;
        }

    }
}
