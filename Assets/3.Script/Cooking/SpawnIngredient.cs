using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingredients;   // ����� ������ִ� ������

    [SerializeField] private Transform _spawnPoint;      // ��������Ʈ

    public void Spawn(int idx)
    {
        Instantiate(_ingredients[idx], _spawnPoint.position, _spawnPoint.rotation);
    }
}
