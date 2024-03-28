using Mirror;
using UnityEngine;

public class CampfireNetworkRig : NetworkBehaviour
{
    // �÷��̾ �������� �Ⱦ��� �� ȣ��Ǵ� Ŀ�ǵ�
    [Command]
    private void CmdPickupItem(NetworkIdentity item)
    {
        // Ŭ���̾�Ʈ���� �������� �Ⱦ��� ������ �ο�
        item.AssignClientAuthority(connectionToClient);
    }

    // �������� ������ �� ȣ��Ǵ� Ŀ�ǵ�
    [Command]
    private void CmdReleaseItem(NetworkIdentity item)
    {
        // Ŭ���̾�Ʈ���� �������� �Ⱦ��� ������ ��ȯ
        item.RemoveClientAuthority();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            // �÷��̾ �����۰� �浹�ϸ� CmdPickupItem ȣ��
            CmdPickupItem(other.GetComponent<NetworkIdentity>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            // �÷��̾ �������� ������ CmdReleaseItem ȣ��
            CmdReleaseItem(other.GetComponent<NetworkIdentity>());
        }
    }
}
