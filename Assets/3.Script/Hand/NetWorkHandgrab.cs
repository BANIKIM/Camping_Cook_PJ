using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.XR.Interaction.Toolkit;

public class NetWorkHandgrab : NetworkBehaviour
{
    private XRGrabInteractable grabInteractable;
    [SyncVar(hook = nameof(OnObjectPositionChanged))]
    public Vector3 objPos;
    [SyncVar(hook = nameof(OnObjectRotationChanged))]
    public Quaternion objRot;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.Log("XR Grab Interactable 컴포넌트를 찾지 못했습니다.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (grabInteractable.isSelected)
        {
            objPos = other.transform.position;
            objRot = other.transform.rotation;
            CmdSyncObjectPosition(objPos, objRot);
        }
    }

    [Command(requiresAuthority = false)]
    void CmdSyncObjectPosition(Vector3 position, Quaternion rotation)
    {
        RpcUpdateObjectPosition(position, rotation);
    }

    [ClientRpc]
    void RpcUpdateObjectPosition(Vector3 position, Quaternion rotation)
    {
        // 클라이언트에서만 실행됨
        objPos = position;
        objRot = rotation;
    }

    // objPos 값이 변경될 때 호출되는 메서드
    void OnObjectPositionChanged(Vector3 oldPos, Vector3 newPos)
    {
        transform.position = newPos;
    }

    // objRot 값이 변경될 때 호출되는 메서드
    void OnObjectRotationChanged(Quaternion oldRot, Quaternion newRot)
    {
        transform.rotation = newRot;
    }
}
