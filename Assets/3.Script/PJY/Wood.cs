using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // 자식 프리팹

    public GameObject Cut_0;
    private GameObject Cut_1;
    private GameObject Cut_2;
    public AudioSource CutWood;

    public float SpawnX;
    public float SpawnY;
    [SerializeField] private float coolTime = 60f;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            CreatePrefabInstances();
        }
    }
    private void Start()
    {
        Destroy(gameObject, coolTime);   // 일정 시간 후에 삭제
    }

    public void CreatePrefabInstances()
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
        CutWood.PlayOneShot(CutWood.clip);
        Debug.Log("wood 소환소리");
        // 부모 오브젝트 비활성화

        Destroy(Cut_0);

        Rigidbody cut1Rigidbody = Cut_1.GetComponent<Rigidbody>();
        Rigidbody cut2Rigidbody = Cut_2.GetComponent<Rigidbody>();
        if (cut1Rigidbody != null && cut2Rigidbody != null)
        {
            cut1Rigidbody.AddForce(Vector3.left * 3f, ForceMode.Impulse);
            cut2Rigidbody.AddForce(Vector3.right * 2f, ForceMode.Impulse);
        }
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
