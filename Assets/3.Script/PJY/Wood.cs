using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // 자식 프리팹

    public GameObject woodPrefab;
    private GameObject woodCut_1;
    private GameObject woodCut_2;
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

    //장작 패는 과정에서 장작생성하는 메서드 
    public void CreatePrefabInstances()
    {
        Vector3 parentPosition = transform.position;

        // 자식 프리팹을 이용하여 자식 오브젝트 생성
        woodCut_1 = Instantiate(childObjPrefab, parentPosition + new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
        woodCut_2 = Instantiate(childObjPrefab, parentPosition + new Vector3(-SpawnX, SpawnY, 0), Quaternion.identity);

      /*  SetColliderProperties(Cut_1);
        SetColliderProperties(Cut_2);*/

        // 부모-자식 관계 끊기
        woodCut_1.transform.parent = null;
        woodCut_2.transform.parent = null;
        CutWood.PlayOneShot(CutWood.clip);
       
        // 부모 오브젝트 삭제
        Destroy(woodPrefab);

        //잘릴때 튕겨나가는 효과
        Rigidbody cut1Rigidbody = woodCut_1.GetComponent<Rigidbody>();
        Rigidbody cut2Rigidbody = woodCut_2.GetComponent<Rigidbody>();
        if (cut1Rigidbody != null && cut2Rigidbody != null)
        {
            cut1Rigidbody.AddForce(Vector3.left * 3f, ForceMode.Impulse);
            cut2Rigidbody.AddForce(Vector3.right * 2f, ForceMode.Impulse);
        }
    }
/*    private void SetColliderProperties(GameObject obj)
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
    }*/




}
