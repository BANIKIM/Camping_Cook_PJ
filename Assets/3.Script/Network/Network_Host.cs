using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Network_Host : MonoBehaviour
{
   public void CreateRoom()
    {
        var manager = NetworkManager.singleton;
        manager.StartHost();
    }
}
