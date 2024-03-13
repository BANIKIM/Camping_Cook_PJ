using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingredients;   // 식재료 모아져있는 프리팹

    [SerializeField] private Transform _spawnPoint;      // 스폰포인트

    public void Spawn(int idx)
    {
        Instantiate(_ingredients[idx], _spawnPoint.position, _spawnPoint.rotation);
    }
}
