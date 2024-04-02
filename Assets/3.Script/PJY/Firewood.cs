using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    [SerializeField] private float coolTime = 90f;  // 쿨타임

    public AudioSource cutSound;

    //장작이 생성되고 사용되지 않는다면 90초후에 삭제
    private void Start()
    {
        Destroy(gameObject, coolTime);
        cutSound.PlayOneShot(cutSound.clip);
    }
}
