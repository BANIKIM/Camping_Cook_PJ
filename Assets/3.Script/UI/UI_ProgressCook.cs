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
    public TextMeshProUGUI _difficultyText;
    public GameObject[] _cookingOrder;
    [SerializeField] private TextMeshProUGUI _recipeName;
    [SerializeField] private Image _cookImg;
    [SerializeField] private Sprite[] _cookAllImgs;


    public string[] _cookNameArr = new string[5] { "마쉬멜로우", "비프 스튜", "꼬치 플래터", "스테이크", "연어 스테이크" };

    public void StartProgress(int idx)
    {
        _progressImg.sprite = _cookAllImgs[idx];
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
