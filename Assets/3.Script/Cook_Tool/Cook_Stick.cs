using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook_Stick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Transform childTransform = collision.gameObject.transform;
            Transform parentTransform = gameObject.transform;

            // ���� ������ ����
            Vector3 originalScale = childTransform.localScale;

            // �浹�� ������Ʈ�� �θ� ������Ʈ�� �ڽ����� ����
            childTransform.parent = parentTransform;

            // ���� �������� ���� �����Ϸ� �ٽ� ����
            childTransform.localScale = originalScale;

            // �߷� ��Ȱ��ȭ
            Rigidbody childRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (childRigidbody != null)
            {
                childRigidbody.useGravity = false;
            }
        }
    }
}
