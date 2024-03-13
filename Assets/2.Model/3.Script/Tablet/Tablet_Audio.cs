using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Tablet_Audio : MonoBehaviour
{
    [SerializeField] private Slider[] _volumeSliders;  // Master, BGM, SFX
    private string[] _parameterArr = new string[3] { "Master", "BGM", "SFX" };
    [SerializeField] private TextMeshProUGUI[] _valueTexts;
    [SerializeField] private AudioMixer _audioMixer;

    private void Start()
    {
        Default_Setting();
    }

    public void ChangeValue(int idx)
    {
        float value = _volumeSliders[idx].value;
        // value = 0.001 ~ 1
        _audioMixer.SetFloat(_parameterArr[idx], Mathf.Log10(value) * 20);
        _valueTexts[idx].text = $"{(int)(_volumeSliders[idx].value * 100)}";
    }

    private void Default_Setting()
    {
        for (int i = 0; i < _volumeSliders.Length; i++)
        {
            ChangeValue(i);
        }
    }
}
