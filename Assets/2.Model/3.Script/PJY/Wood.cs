using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // �ڽ� ������

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
        Destroy(gameObject, coolTime);   // ���� �ð� �Ŀ� ����
    }

    public void CreatePrefabInstances()
    {
        Vector3 parentPosition = transform.position;

        // �ڽ� �������� �̿��Ͽ� �ڽ� ������Ʈ ����
        Cut_1 = Instantiate(childObjPrefab, parentPosition + new Vector3(SpawnX, SpawnY, 0), Quaternion.identity);
        Cut_2 = Instantiate(childObjPrefab, parentPosition + new Vector3(-SpawnX, SpawnY, 0), Quaternion.identity);

        SetColliderProperties(Cut_1);
        SetColliderProperties(Cut_2);

        // �θ�-�ڽ� ���� ����
        Cut_1.transform.parent = null;
        Cut_2.transform.parent = null;
        CutWood.PlayOneShot(CutWood.clip);
        Debug.Log("wood ��ȯ�Ҹ�");
        // �θ� ������Ʈ ��Ȱ��ȭ

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
    }




}