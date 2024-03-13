using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    [SerializeField] private float coolTime = 90f;  // ��Ÿ��

    public AudioSource cutSound;

    private void Start()
    {
        Destroy(gameObject, coolTime);
        cutSound.PlayOneShot(cutSound.clip);
    }
}
