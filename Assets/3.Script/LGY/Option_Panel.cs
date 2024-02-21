using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Option_Panel : MonoBehaviour
{
    public static Option_Panel instance = null;

    public Slider[] _volumeSliders;  // Master, BGM, SFX
    public Dictionary<int, string> _para_D = new Dictionary<int, string>();
    public TextMeshProUGUI[] _texts;

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
        float value = _volumeSliders[idx].value;
        // value = 0.001 ~ 1
        AudioManager.instance._audioMixer.SetFloat(_para_D[idx], Mathf.Log10(value) * 20);
        _texts[idx].text = $"{(int)(_volumeSliders[idx].value * 100)}";
    }



    private void Add_ParameterKey()
    {
        _para_D.Add(0, "Master");
        _para_D.Add(1, "BGM");
        _para_D.Add(2, "SFX");
    }

    private void Default_Setting()
    {
        for (int i = 0; i < _volumeSliders.Length; i++)
        {
            ChangeValue(i);
        }
    }



}
