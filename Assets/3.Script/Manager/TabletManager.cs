using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Tablet_Star))]
[RequireComponent(typeof(Tablet_ProgressCook))]
[RequireComponent(typeof(Tablet_CookingTimer))]

public class TabletManager : MonoBehaviour
{
    public static TabletManager instance = null;

    [HideInInspector] public Tablet_Star _tablet_Star;
    [HideInInspector] public Tablet_ProgressCook _tablet_ProgressCook;
    [HideInInspector] public Tablet_CookingTimer _tablet_CookingTimer;

    // ===============================================

    // Tablet AudioSource 
    [SerializeField] private AudioSource _audioSource;


    [Header("Home")]
    public TextMeshProUGUI _userNameText;
    public TextMeshProUGUI _campingLvText;
    public Slider _campingExpSlider;
    public TextMeshProUGUI _starCountText;
    public TextMeshProUGUI _trophyCountText;
    public TextMeshProUGUI _coinCountText;

    [Header("Mod")]
    public TextMeshProUGUI[] _gameModText;
    [SerializeField] private GameObject _secretObj;

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
        TryGetComponent(out _tablet_Star);
        TryGetComponent(out _tablet_CookingTimer);
        TryGetComponent(out _tablet_ProgressCook);
    }

    // ���� �������� �� UI ����
    public void UIStartGameEvent(int idx)
    {
        if (!GameManager.instance.isCookingStart) return;

        _audioSource.PlayOneShot(AudioManager.instance._sfxClips[(int)SFX_List.CookStart]);

        if (GameManager.instance._gameMod.Equals(GameManager.GameMod.Challenge)) // ���� ���
        {
            _secretObj.SetActive(true);
            _tablet_CookingTimer.ChallengeTimer(60);
        }
        else   // �Ϲ� ���
        {
            _tablet_ProgressCook.StartProgress(idx);
            _tablet_CookingTimer.OnCookingTimer(true, idx);
        }
    }

    public void UIEndGameEvent(int idx)
    {
        _tablet_CookingTimer.OnCookingTimer(false, idx);
        _secretObj.SetActive(false);
        _tablet_ProgressCook.EndProgress();

    }

    // ���� ��� �ٲ�
    public void ChangeGameMod(int cookNum, int mod)
    {
        _gameModText[cookNum].text = mod.Equals(0) ? "�Ϲ�" : "���� ���";
    }

    // ��ư ����
    public void BtnSound()
    {
        _audioSource.PlayOneShot(AudioManager.instance._sfxClips[(int)SFX_List.Btn]);
    }



}
