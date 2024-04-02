using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Network_Host : MonoBehaviour
{
    //Host로 네트워크 방만들기
   public void CreateRoom()
    {
        var manager = NetworkManager.singleton;
        manager.StartHost();
    }
}
