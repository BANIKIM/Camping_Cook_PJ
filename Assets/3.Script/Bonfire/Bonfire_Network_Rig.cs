using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bonfire_Network_Rig : NetworkBehaviour
{
    // 플레이어가 아이템을 픽업할 때 호출되는 커맨드
    [Command]
    void CmdPickupItem(NetworkIdentity item)
    {
        // 클라이언트에게 아이템을 픽업할 권한을 부여
        item.AssignClientAuthority(connectionToClient);
    }

    // 아이템을 놓았을 때 호출되는 커맨드
    [Command]
    void CmdReleaseItem(NetworkIdentity item)
    {
        // 클라이언트에게 아이템을 픽업할 권한을 반환
        item.RemoveClientAuthority();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("나무장작이다아아아아!");
            // 플레이어가 아이템과 충돌하면 CmdPickupItem 호출
            CmdPickupItem(other.GetComponent<NetworkIdentity>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("나무장작을 놓았습니다.");
            // 플레이어가 아이템을 놓으면 CmdReleaseItem 호출
            CmdReleaseItem(other.GetComponent<NetworkIdentity>());
        }
    }
}
