using System.Collections;
using UnityEngine;

public class Firewood : MonoBehaviour
{
    [SerializeField] private float coolTime = 90f;  // 쿨타임

    private void Start()
    {
        Destroy(gameObject, coolTime);
    }
    /*
        private IEnumerator DestroyAfterCoolTime()
        {
            yield return new WaitForSeconds(coolTime); // 쿨타임 대기

            // 쿨타임 종료 후 자신 파괴

        }*/
}
