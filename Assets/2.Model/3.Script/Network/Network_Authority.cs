using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Network_Authority : NetworkBehaviour
{

    [Command]
    void CmdPickupItem(NetworkIdentity item)
    {
        item.AssignClientAuthority(connectionToClient);
    }
    private void OnTriggerStay(Collider other)
    {
        CmdPickupItem(other.transform.GetComponent<NetworkIdentity>());
    }
}
