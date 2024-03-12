using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Mirror;

public class NetworkIgnite : NetworkBehaviour
{
    public GameObject _fireEffect;
    public XRGrabInteractable _grabInteractable;
    public AudioSource _audioSource;

    private void FixedUpdate()
    {
        if (isServer)
        {
            if (!_grabInteractable.isSelected)
            {
                _fireEffect.SetActive(false);
                RpcStopAudio();
            }
        }
    }

    [ClientRpc]
    void RpcStopAudio()
    {
        _audioSource.Stop();
    }

    // Ŭ���̾�Ʈ���� ������ OnOffFire ȣ���� ����
    [Command]
    public void CmdOnOffFire(bool isignite)
    {
        // fire ���� ������Ʈ�� Ȱ��ȭ ���¸� ���
        _fireEffect.SetActive(isignite);

        if (isignite)
        {
            RpcPlayAudio();
        }
        else
        {
            RpcStopAudio();
        }
    }

    [ClientRpc]
    void RpcPlayAudio()
    {
        _audioSource.Play();
    }
}
