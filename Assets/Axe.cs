using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private float chopThresholdSpeed = 1f; // ������ �߸��� �ּ� �ӵ�
    [SerializeField] private float chopThresholdAngle = 45f; // ������ �߸��� �ּ� ����
    [SerializeField] private Wood wood;
  


    private void Update()
    {
        wood = GameObject.FindGameObjectWithTag("Wood").GetComponent<Wood>();
        // ���̸� �� ���� ���� ���� (���� ������Ʈ�� ��ġ)
        Vector3 rayOrigin = transform.position;

        // ���̸� �� ���� ���� (���� ���, �Ʒ��� ��� �������� ����)
        Vector3 rayDirection = Vector3.down*0.3f;

        // ���̸� �ð�ȭ�Ͽ� Scene �信�� Ȯ��
        Debug.DrawRay(rayOrigin, rayDirection * 0.3f, Color.red, 1f);

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit))
        {
            // �浹�� ������Ʈ�� 'Wood' �±׸� ������ �ִ� ���
            if (hit.collider.CompareTag("Wood"))
            {
                // �浹�� ������Ʈ�� Rigidbody ������Ʈ�� ������
                Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (hitRigidbody != null)
                {
                    // �浹�� ������Ʈ�� �ӵ��� ������
                    Vector3 impactForce = hitRigidbody.velocity;
                    float impactSpeed = impactForce.magnitude;
                    float angle = Vector3.Angle(Vector3.up, hit.normal);
                    Debug.Log(impactForce);
                   // Debug.Log(angle);
                    if (impactSpeed >= chopThresholdSpeed && angle <= chopThresholdAngle)
                    {
                        wood.CreatePrefabInstances();
                    }
                }
            }
        }
    }

}
