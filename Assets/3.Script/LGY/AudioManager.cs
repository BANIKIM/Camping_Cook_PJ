using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioClip[] _bgmClips;
    public AudioClip[] _sfxClips;

    public AudioMixer _audioMixer;


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
