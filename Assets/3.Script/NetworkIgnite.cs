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

    // 클라이언트에서 서버로 OnOffFire 호출을 보냄
    [Command]
    public void CmdOnOffFire(bool isignite)
    {
        // fire 게임 오브젝트의 활성화 상태를 토글
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
