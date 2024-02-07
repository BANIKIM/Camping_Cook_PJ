using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    public float coolTime = 90f;  // 쿨타임

    private void Start()
    {
        StartCoroutine(DestroyAfterCoolTime());
    }

    private IEnumerator DestroyAfterCoolTime()
    {
        yield return new WaitForSeconds(coolTime); // 쿨타임 대기

        // 쿨타임 종료 후 자신 파괴
        Destroy(gameObject);
    }
}
