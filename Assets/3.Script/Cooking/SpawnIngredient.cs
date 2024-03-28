using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;   // 식재료 모아져있는 프리팹
    [SerializeField] private Transform spawnPoint;      // 스폰포인트

    public void Spawn(int idx)
    {
        Instantiate(ingredients[idx], spawnPoint.position, spawnPoint.rotation);
    }
}
