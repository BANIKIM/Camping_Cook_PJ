using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BGM_List
{

}

public enum SFX_List
{
    FoodToGrill = 0,
    SliceMeat,
    SliceVegetable1,
    SliceVegetable2,
    BoilingWater,
    Seasoning,

}

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

    public void Play_Audio(AudioSource source, int idx)
    {
        source.clip = _sfxClips[idx];
        source.Play();
    }
}
