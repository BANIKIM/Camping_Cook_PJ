using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework_firing : MonoBehaviour
{
    public bool firing = false;
    public GameObject[] firing_pad; // 발사게임오브젝트
    public GameObject aa;


    private void FixedUpdate()
    {
        
        //트루가 된다면
        if(firing)
        {
            for (int i = 0; i < firing_pad.Length; i++)
            {
              GameObject clen = Instantiate(aa, firing_pad[0].transform);
                //필요한건 밀어내는힘과 폭죽이 터지는데 까지 걸리는 시간인데
                clen.transform.GetChild(0).gameObject.SetActive(true);// 클론의 폭죽 이펙트 활성화

            }
        }
    }
}
