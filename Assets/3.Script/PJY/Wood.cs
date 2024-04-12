using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // �ڽ� ������

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
        Destroy(gameObject, coolTime);   // ���� �ð� �Ŀ� ����
    }

    //���� �д� �������� ���ۻ����ϴ� �޼��� 
    public void CreatePrefabInstances()
    {
        Vector3 parentPosition = transform.position;

        // �ڽ� �������� �̿��Ͽ� �ڽ� ������Ʈ ����
        woodCut_1 = Instantiate(childObjPrefab, parentPosition + new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
        woodCut_2 = Instantiate(childObjPrefab, parentPosition + new Vector3(-SpawnX, SpawnY, 0), Quaternion.identity);

      /*  SetColliderProperties(Cut_1);
        SetColliderProperties(Cut_2);*/

        // �θ�-�ڽ� ���� ����
        woodCut_1.transform.parent = null;
        woodCut_2.transform.parent = null;
        CutWood.PlayOneShot(CutWood.clip);
       
        // �θ� ������Ʈ ����
        Destroy(woodPrefab);

        //�߸��� ƨ�ܳ����� ȿ��
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
        // �ڽ� ������Ʈ�� Collider ������Ʈ�� �ִٸ� ����
        BoxCollider objCollider = obj.GetComponent<BoxCollider>();
        if (objCollider != null)
        {
            // �ݶ��̴��� ��Ȱ��ȭ�Ͽ� �浹�� ����
            objCollider.isTrigger = false;
        }

        // �ڽ� ������Ʈ�� Rigidbody ������Ʈ�� �ִٸ� ����
        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        if (objRigidbody != null)
        {
            // ������ٵ� ��Ȱ��ȭ�Ͽ� ���� ������ ����
            objRigidbody.isKinematic = false;
        }
    }*/




}
