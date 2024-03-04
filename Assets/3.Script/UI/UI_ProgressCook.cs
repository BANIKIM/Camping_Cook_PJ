using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_ProgressCook : MonoBehaviour
{
    [SerializeField] private GameObject _progressCooking;
    [SerializeField] private Image _progressImg;
    [SerializeField] private TextMeshProUGUI _progressCookName;

    public string[] _cookNameArr = new string[5] { "������ο�", "���� ��Ʃ", "��ġ �÷���", "������ũ", "���� ������ũ" };

    public void StartProgress(int idx)
    {
        _progressImg.sprite = TabletManager.instance._cookAllImgs[idx];
        _progressCookName.text = _cookNameArr[idx];
        _progressCooking.SetActive(true);
    }

    public void EndProgress()
    {
        _progressImg.sprite = null;
        _progressCookName.text = null;
        _progressCooking.SetActive(false);
    }
}