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

    private string[] _cookNameArr = new string[5] { "������ο�", "���� ��Ʃ", "��ġ �÷���", "������ũ", "���� ������ũ" };

    public void StartProgress()
    {
        _progressImg.sprite = TabletManager.instance._cookAllImgs[GameManager.instance._cookIdx];
        _progressCookName.text = _cookNameArr[GameManager.instance._cookIdx];
        _progressCooking.SetActive(true);
    }

    public void EndProgress()
    {
        _progressImg.sprite = null;
        _progressCookName.text = null;
        _progressCooking.SetActive(false);
    }
}
