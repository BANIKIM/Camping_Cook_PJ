using UnityEngine;

public class FireWood : MonoBehaviour
{
    [SerializeField] private GameObject fireWood;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            for (int i = 0; i < fireWood.transform.childCount; i++)
            {
                if (fireWood.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    fireWood.transform.GetChild(i).gameObject.SetActive(true);
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
