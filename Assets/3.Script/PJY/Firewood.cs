using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    [SerializeField] private float coolTime = 90f;  // ��Ÿ��

    private void Start()
    {
        Destroy(gameObject, coolTime);
    }
}
