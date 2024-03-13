using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Network_Client : MonoBehaviour
{
    [SerializeField] private Text ip;


    public void Start_Client()
    {
        NetworkManager.singleton.networkAddress = ip.text;
        NetworkManager.singleton.StartClient();

    }
}
