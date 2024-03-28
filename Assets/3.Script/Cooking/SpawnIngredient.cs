using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;   // ����� ������ִ� ������
    [SerializeField] private Transform spawnPoint;      // ��������Ʈ

    public void Spawn(int idx)
    {
        Instantiate(ingredients[idx], spawnPoint.position, spawnPoint.rotation);
    }
}
