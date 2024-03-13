using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tablet_ProgressCook : MonoBehaviour
{
    private string[] _cookNames = new string[5] { "마쉬멜로우", "소고기 스튜", "연어 스테이크", "소고기 스테이크", "꼬치 플래터" };

    [Header("Resource")]
    [SerializeField] private Sprite[] _cookImgs;

    [Header("Recipe")]
    [SerializeField] private TextMeshProUGUI _recipeNameText;
    [SerializeField] private GameObject[] _recipes;

    [Header("Progress")]
    [SerializeField] private TextMeshProUGUI _progressCookingNameText;
    [SerializeField] private Image _progresscookingImgs;
    [SerializeField] private GameObject _progressCooking;


    public void SelectRecipe(int idx)
    {
        _recipeNameText.text = _cookNames[idx];
        _recipes[idx].SetActive(true);
    }

    public void BackBtn()
    {
        for (int i = 0; i < _recipes.Length; i++)
        {
            _recipes[i].SetActive(false);
        }
    }



    public void StartProgress(int idx)
    {
        _progressCooking.SetActive(true);
        _progressCookingNameText.text = _cookNames[idx];
        _progresscookingImgs.sprite = _cookImgs[idx];
    }

    public void EndProgress()
    {
        _progressCooking.SetActive(false);
    }
}
