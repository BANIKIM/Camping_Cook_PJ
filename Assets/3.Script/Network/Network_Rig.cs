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

    private void Start()
    {
        if(isLocalPlayer)
        {
            hardware_rig = GameObject.FindWithTag("Player").GetComponent<Hardware_Rig>();
        }
    }

    private void LateUpdate()
    {
        if (hardware_rig != null)
        {
            transform.SetPositionAndRotation(hardware_rig.transform.position, hardware_rig.transform.rotation);
            leftNetworkHand.transform.SetPositionAndRotation(hardware_rig.left_Hand_Position, hardware_rig.left_Hand_Rotation);
            rightNetworkHand.transform.SetPositionAndRotation(hardware_rig.right_Hand_Position, hardware_rig.right_Hand_Rotation);
            networkHead.transform.SetPositionAndRotation(hardware_rig.head_Set_Position, hardware_rig.head_Set_Rotation);
        }

    }


}
