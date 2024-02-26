using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillSound : MonoBehaviour
{
    [SerializeField] private Tool_heat _toolHeat;
    [SerializeField] private AudioSource _audiosource;

    private void FixedUpdate()
    {
        if (_toolHeat.tool_heat && !_audiosource.isPlaying)
        {
            _audiosource.Play();
        }
        else if (!_toolHeat.tool_heat && _audiosource.isPlaying)
        {
            _audiosource.Stop();
        }
    }

}
