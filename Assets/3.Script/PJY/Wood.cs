using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // 자식 프리팹

    public GameObject Cut_0;
    private GameObject Cut_1;
    private GameObject Cut_2;

    public float SpawnX;
    public float SpawnY;
    [SerializeField] private float coolTime = 60f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Axe"))
        {
            CreatePrefabInstances();
        }

    }
    private void Start()
    {
        Destroy(gameObject, coolTime);
    }

    /*  private IEnumerator DestroyAfterCoolTime()
      {
          yield return new WaitForSeconds(coolTime); // 쿨타임 대기

          // 쿨타임 종료 후 자신 파괴

      }*/
    private void CreatePrefabInstances()
    {
        Vector3 parentPosition = transform.position;

        // 자식 프리팹을 이용하여 자식 오브젝트 생성
        Cut_1 = Instantiate(childObjPrefab, parentPosition + new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
        Cut_2 = Instantiate(childObjPrefab, parentPosition + new Vector3(-SpawnX, SpawnY, 0), Quaternion.identity);

        SetColliderProperties(Cut_1);
        SetColliderProperties(Cut_2);

        // 부모-자식 관계 끊기
        Cut_1.transform.parent = null;
        Cut_2.transform.parent = null;

        // 부모 오브젝트 비활성화

        Destroy(Cut_0);
    }
    private void SetColliderProperties(GameObject obj)
    {
        // 자식 오브젝트에 Collider 컴포넌트가 있다면 설정
        BoxCollider objCollider = obj.GetComponent<BoxCollider>();
        if (objCollider != null)
        {
            // 콜라이더를 비활성화하여 충돌을 무시
            objCollider.isTrigger = false;
        }

        // 자식 오브젝트에 Rigidbody 컴포넌트가 있다면 설정
        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        if (objRigidbody != null)
        {
            // 리지드바디를 비활성화하여 물리 연산을 무시
            objRigidbody.isKinematic = false;
        }
    }




}
