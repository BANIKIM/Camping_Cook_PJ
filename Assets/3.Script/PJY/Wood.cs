using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // 자식 프리팹

    public GameObject parentObj;
    private GameObject childObj1;
    private GameObject childObj2;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Knife"))
        {
            CreatePrefabInstances();
        }

    }
    private void CreatePrefabInstances()
    {
        Vector3 parentPosition = transform.position;

        // 자식 프리팹을 이용하여 자식 오브젝트 생성
        childObj1 = Instantiate(childObjPrefab, parentPosition + new Vector3(0, 0, 0), Quaternion.identity);
        childObj2 = Instantiate(childObjPrefab, parentPosition + new Vector3(0, 0, 0), Quaternion.identity);

        SetColliderProperties(childObj1);
        SetColliderProperties(childObj2);

        // 부모-자식 관계 끊기
        childObj1.transform.parent = null;
        childObj2.transform.parent = null;

        // 부모 오브젝트 비활성화
      
        Destroy(parentObj);
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
