using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    public float coolTime = 90f;  // ��Ÿ��

    private void Start()
    {
        StartCoroutine(DestroyAfterCoolTime());
    }

    private IEnumerator DestroyAfterCoolTime()
    {
        yield return new WaitForSeconds(coolTime); // ��Ÿ�� ���

        // ��Ÿ�� ���� �� �ڽ� �ı�
        Destroy(gameObject);
    }
}
