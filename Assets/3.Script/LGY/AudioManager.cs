using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioClip[] BGM_Clips;
    public AudioClip[] SFX_Clips;

    public AudioMixer audiomixer;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }
    }

    public void Play_Audio(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}