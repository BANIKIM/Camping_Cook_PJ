using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    [SerializeField] private float coolTime = 90f;  // ��Ÿ��

    public AudioSource cutSound;

    //������ �����ǰ� ������ �ʴ´ٸ� 90���Ŀ� ����
    private void Start()
    {
        Destroy(gameObject, coolTime);
        cutSound.PlayOneShot(cutSound.clip);
    }
}
