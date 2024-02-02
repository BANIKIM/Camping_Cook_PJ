using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Network_Rig : NetworkBehaviour
{

    public Hardware_Rig hardware_rig;

    public Network_Hand leftNetworkHand;
    public Network_Hand rightNetworkHand;
    public Network_Head networkHead;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        hardware_rig = GameObject.FindWithTag("Player").GetComponent<Hardware_Rig>();
    }

    private void Update()
    {
        if (isLocalPlayer && hardware_rig != null)
        {
            CmdUpdateRigTransform(hardware_rig.transform.position, hardware_rig.transform.rotation,
                hardware_rig.left_Hand_Position, hardware_rig.left_Hand_Rotation,
                hardware_rig.right_Hand_Position, hardware_rig.right_Hand_Rotation,
                hardware_rig.head_Set_Position, hardware_rig.head_Set_Rotation);
        }
    }

    [Command]
    void CmdUpdateRigTransform(Vector3 position, Quaternion rotation, Vector3 leftHandPosition, Quaternion leftHandRotation,
        Vector3 rightHandPosition, Quaternion rightHandRotation, Vector3 headPosition, Quaternion headRotation)
    {
        RpcUpdateRigTransform(position, rotation, leftHandPosition, leftHandRotation,
            rightHandPosition, rightHandRotation, headPosition, headRotation);
    }

    [ClientRpc]
    void RpcUpdateRigTransform(Vector3 position, Quaternion rotation, Vector3 leftHandPosition, Quaternion leftHandRotation,
        Vector3 rightHandPosition, Quaternion rightHandRotation, Vector3 headPosition, Quaternion headRotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        leftNetworkHand.transform.SetPositionAndRotation(leftHandPosition, leftHandRotation);
        rightNetworkHand.transform.SetPositionAndRotation(rightHandPosition, rightHandRotation);
        networkHead.transform.SetPositionAndRotation(headPosition, headRotation);
    }
}