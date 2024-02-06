using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameObject childObjPrefab;  // �ڽ� ������

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

        // �ڽ� �������� �̿��Ͽ� �ڽ� ������Ʈ ����
        childObj1 = Instantiate(childObjPrefab, parentPosition + new Vector3(0, 0, 0), Quaternion.identity);
        childObj2 = Instantiate(childObjPrefab, parentPosition + new Vector3(0, 0, 0), Quaternion.identity);

        SetColliderProperties(childObj1);
        SetColliderProperties(childObj2);

        // �θ�-�ڽ� ���� ����
        childObj1.transform.parent = null;
        childObj2.transform.parent = null;

        // �θ� ������Ʈ ��Ȱ��ȭ
      
        Destroy(parentObj);
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
