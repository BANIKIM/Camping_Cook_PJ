using UnityEngine;

public class CampingBox : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;

    private void Start()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].transform.parent = null;
        }
    }
}
