using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] _ingredients;   // ����� ������ִ� ������

    [SerializeField] private Transform _spawnPoint;      // ��������Ʈ

    public void Spawn(int idx) 
    {
       
        // Instantiate�� ����
        GameObject spawnobj =  Instantiate(_ingredients[idx], _spawnPoint.position, Quaternion.identity);

        // ��ӵ� ������Ʈ ������ �ٲ�
        for (int i = 0; i < spawnobj.transform.childCount; i++)
        {
            spawnobj.transform.GetChild(i).transform.parent = null;
        }

    }
}
