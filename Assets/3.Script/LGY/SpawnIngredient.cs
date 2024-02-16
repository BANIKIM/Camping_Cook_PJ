using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;   // ����� ������ִ� ������

    [SerializeField] private Transform spawn_point;      // ��������Ʈ

    public void Spawn(int idx) 
    {
        // Instantiate�� ����
        GameObject spawnobj =  Instantiate(ingredients[idx], spawn_point.position, Quaternion.identity);

        // ��ӵ� ������Ʈ ������ �ٲ�
        for (int i = 0; i < spawnobj.transform.childCount; i++)
        {
            spawnobj.transform.GetChild(i).transform.parent = null;
        }

    }
}
