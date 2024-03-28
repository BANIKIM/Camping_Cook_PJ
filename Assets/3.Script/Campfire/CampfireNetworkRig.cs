using Mirror;
using UnityEngine;

public class CampfireNetworkRig : NetworkBehaviour
{
    // 플레이어가 아이템을 픽업할 때 호출되는 커맨드
    [Command]
    private void CmdPickupItem(NetworkIdentity item)
    {
        // 클라이언트에게 아이템을 픽업할 권한을 부여
        item.AssignClientAuthority(connectionToClient);
    }

    // 아이템을 놓았을 때 호출되는 커맨드
    [Command]
    private void CmdReleaseItem(NetworkIdentity item)
    {
        // 클라이언트에게 아이템을 픽업할 권한을 반환
        item.RemoveClientAuthority();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            // 플레이어가 아이템과 충돌하면 CmdPickupItem 호출
            CmdPickupItem(other.GetComponent<NetworkIdentity>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            // 플레이어가 아이템을 놓으면 CmdReleaseItem 호출
            CmdReleaseItem(other.GetComponent<NetworkIdentity>());
        }
    }
}
