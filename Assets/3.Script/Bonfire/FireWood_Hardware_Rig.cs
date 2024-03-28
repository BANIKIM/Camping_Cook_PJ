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
            syncedPosition = transform.position;
            syncedRotation = transform.rotation;
        }
    }

    [ClientCallback]
    private void OnPositionChanged(Vector3 oldPosition, Vector3 newPosition)
    {
        if (!isServer)
        {
            transform.position = newPosition;
        }
    }

    [ClientCallback]
    private void OnRotationChanged(Quaternion oldRotation, Quaternion newRotation)
    {
        if (!isServer)
        {
            transform.rotation = newRotation;
        }
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            // ���� �÷��̾��� �Է��� �����Ͽ� ��ġ �� ȸ���� ����
            CmdUpdateRigTransform(transform.position, transform.rotation);
        }
    }

    [Command]
    private void CmdUpdateRigTransform(Vector3 position, Quaternion rotation)
    {
        syncedPosition = position;
        syncedRotation = rotation;
    }
}
