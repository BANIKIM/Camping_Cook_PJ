using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bonfire_Network_Rig : NetworkBehaviour
{
    // �÷��̾ �������� �Ⱦ��� �� ȣ��Ǵ� Ŀ�ǵ�
    [Command]
    void CmdPickupItem(NetworkIdentity item)
    {
        // Ŭ���̾�Ʈ���� �������� �Ⱦ��� ������ �ο�
        item.AssignClientAuthority(connectionToClient);
    }

    // �������� ������ �� ȣ��Ǵ� Ŀ�ǵ�
    [Command]
    void CmdReleaseItem(NetworkIdentity item)
    {
        // Ŭ���̾�Ʈ���� �������� �Ⱦ��� ������ ��ȯ
        item.RemoveClientAuthority();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("���������̴پƾƾƾ�!");
            // �÷��̾ �����۰� �浹�ϸ� CmdPickupItem ȣ��
            CmdPickupItem(other.GetComponent<NetworkIdentity>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("���������� ���ҽ��ϴ�.");
            // �÷��̾ �������� ������ CmdReleaseItem ȣ��
            CmdReleaseItem(other.GetComponent<NetworkIdentity>());
        }
    }
}
