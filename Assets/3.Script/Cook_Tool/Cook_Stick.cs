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

            // 현재 스케일 저장
            Vector3 originalScale = childTransform.localScale;

            // 충돌한 오브젝트를 부모 오브젝트의 자식으로 설정
            childTransform.parent = parentTransform;

            // 로컬 스케일을 원래 스케일로 다시 설정
            childTransform.localScale = originalScale;

            // 중력 비활성화
            Rigidbody childRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (childRigidbody != null)
            {
                childRigidbody.useGravity = false;
            }
        }
    }
}
