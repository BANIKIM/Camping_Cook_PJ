using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private float chopThresholdSpeed = 1f; // 장작이 잘리는 최소 속도
    [SerializeField] private float chopThresholdAngle = 45f; // 장작이 잘리는 최소 각도
    [SerializeField] private Wood wood;
  


    private void Update()
    {
        wood = GameObject.FindGameObjectWithTag("Wood").GetComponent<Wood>();
        // 레이를 쏠 시작 지점 설정 (현재 오브젝트의 위치)
        Vector3 rayOrigin = transform.position;

        // 레이를 쏠 방향 설정 (예를 들어, 아래로 쏘는 방향으로 설정)
        Vector3 rayDirection = Vector3.down*0.3f;

        // 레이를 시각화하여 Scene 뷰에서 확인
        Debug.DrawRay(rayOrigin, rayDirection * 0.3f, Color.red, 1f);

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit))
        {
            // 충돌한 오브젝트가 'Wood' 태그를 가지고 있는 경우
            if (hit.collider.CompareTag("Wood"))
            {
                // 충돌된 오브젝트의 Rigidbody 컴포넌트를 가져옴
                Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (hitRigidbody != null)
                {
                    // 충돌된 오브젝트의 속도를 가져옴
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
