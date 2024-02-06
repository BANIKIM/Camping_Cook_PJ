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
            Debug.Log("XR Grab Interactable ������Ʈ�� ã�� ���߽��ϴ�.");
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
        // Ŭ���̾�Ʈ������ �����
        transform.position = position;
        transform.rotation = rotation;
    }
}
