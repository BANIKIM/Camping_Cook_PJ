using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option_Panel : MonoBehaviour
{
    public static Option_Panel instance = null;

    public Slider[] audio_sliders;  // Master, BGM, SFX
    public Dictionary<int, string> para_D = new Dictionary<int, string>();

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

    private void Start()
    {
        Add_ParameterKey();
        Default_Setting();
    }



    public void ChangeValue(int idx)
    {
        float value = audio_sliders[idx].value;
        // value = 0.001 ~ 1
        AudioManager.instance.audiomixer.SetFloat(para_D[idx], Mathf.Log10(value) * 20);
    }



    private void Add_ParameterKey()
    {
        para_D.Add(0, "Master");
        para_D.Add(1, "BGM");
        para_D.Add(2, "SFX");
    }

    private void Default_Setting()
    {
        for (int i = 0; i < audio_sliders.Length; i++)
        {
            ChangeValue(i);
        }
    }



}
