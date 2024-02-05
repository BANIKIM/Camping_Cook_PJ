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
            // ���������� ����
            syncedPosition = transform.position;
            syncedRotation = transform.rotation;
        }
    }

    [ClientCallback]
    private void OnPositionChanged(Vector3 oldPosition, Vector3 newPosition)
    {
        // ��ġ�� ����Ǿ��� �� Ŭ���̾�Ʈ���� ȣ��Ǵ� �ݹ� �Լ�
        if (!isServer)
        {
            // Ŭ���̾�Ʈ������ ����
            // ����ȭ�� ��ġ������ wood ������Ʈ�� transform�� ������Ʈ
            transform.position = newPosition;
        }
    }

    [ClientCallback]
    private void OnRotationChanged(Quaternion oldRotation, Quaternion newRotation)
    {
        // ȸ���� ����Ǿ��� �� Ŭ���̾�Ʈ���� ȣ��Ǵ� �ݹ� �Լ�
        if (!isServer)
        {
            // Ŭ���̾�Ʈ������ ����
            // ����ȭ�� ȸ�������� wood ������Ʈ�� transform�� ������Ʈ
            transform.rotation = newRotation;
        }
    }
}
