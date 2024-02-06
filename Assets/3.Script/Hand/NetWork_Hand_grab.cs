using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.XR.Interaction.Toolkit;

public class NetWork_Hand_grab : NetworkBehaviour
{
    private XRGrabInteractable grabInteractable;
    [SyncVar]
    public Vector3 objPos;
    [SyncVar]
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
        transform.position = position;
        transform.rotation = rotation;
    }
}
