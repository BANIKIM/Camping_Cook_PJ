using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FireWood_Hardware_Rig : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnPositionChanged))]
    private Vector3 syncedPosition;

    [SyncVar(hook = nameof(OnRotationChanged))]
    private Quaternion syncedRotation;

    private void FixedUpdate()
    {
        if (isServer)
        {
            // 서버에서만 실행
            syncedPosition = transform.position;
            syncedRotation = transform.rotation;
        }
    }

    [ClientCallback]
    private void OnPositionChanged(Vector3 oldPosition, Vector3 newPosition)
    {
        // 위치가 변경되었을 때 클라이언트에서 호출되는 콜백 함수
        if (!isServer)
        {
            // 클라이언트에서만 실행
            // 동기화된 위치값으로 wood 오브젝트의 transform을 업데이트
            transform.position = newPosition;
        }
    }

    [ClientCallback]
    private void OnRotationChanged(Quaternion oldRotation, Quaternion newRotation)
    {
        // 회전이 변경되었을 때 클라이언트에서 호출되는 콜백 함수
        if (!isServer)
        {
            // 클라이언트에서만 실행
            // 동기화된 회전값으로 wood 오브젝트의 transform을 업데이트
            transform.rotation = newRotation;
        }
    }
}
