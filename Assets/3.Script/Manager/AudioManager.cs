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
    GrillLoopS = 6,
    GrillLoopE = 11,
    Btn = 12,
    CookStart = 13,

}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioClip[] _bgmClips;
    public AudioClip[] _sfxClips;

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

    // 오디오 실행시키는 메서드
    public void Play_Audio(AudioSource source, int idx)
    {
        source.clip = _sfxClips[idx];

        if (!source.isPlaying) source.Play();
    }
}
