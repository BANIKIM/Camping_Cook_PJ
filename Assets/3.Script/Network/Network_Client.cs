using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Network_Client : MonoBehaviour
{
    [SerializeField] private Text ip;


    //ip가 일치하다면 네트워크 클라이언트로 접속 
    public void Start_Client()
    {
        if(ip.text!="")
        {
            NetworkManager.singleton.networkAddress = ip.text;
            NetworkManager.singleton.StartClient();
        }
       

    }
}
