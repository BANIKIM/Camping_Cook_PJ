using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Network_Client : MonoBehaviour
{
    [SerializeField] private Text ip;


    //ip�� ��ġ�ϴٸ� ��Ʈ��ũ Ŭ���̾�Ʈ�� ���� 
    public void Start_Client()
    {
        if(ip.text!="")
        {
            NetworkManager.singleton.networkAddress = ip.text;
            NetworkManager.singleton.StartClient();
        }
       

    }
}
