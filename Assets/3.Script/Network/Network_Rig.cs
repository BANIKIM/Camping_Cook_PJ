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


}
