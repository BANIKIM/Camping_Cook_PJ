using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;


    private void Start()
    {
        TryGetComponent(out _audiosource);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CookTool") && !_audiosource.isPlaying)
        {
            int temp = Random.Range((int)SFX_List.GrillLoopS, (int)SFX_List.GrillLoopE + 1);
            AudioManager.instance.Play_Audio(_audiosource, temp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CookTool") && _audiosource.isPlaying)
        {
            _audiosource.Stop();
        }
    }
}
