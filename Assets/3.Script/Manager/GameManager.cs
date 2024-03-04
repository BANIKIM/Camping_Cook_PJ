using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject[] _tools;
    [SerializeField] private Transform[] _toolsPos;

    public int _level = 1;
    public float _needExp = 100f;
    public float _currentExp = 0f;
    public int _cookIdx;
    public int _idxTemp;

    public int _star = 0;
    public int _trophy = 0;

    public bool isCookingStart = false;

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

    public void StartCooking()
    {
        if (isCookingStart)
        {
            if (_idxTemp.Equals(_cookIdx)) return;

            else
            {
                StopCooking();
            }
        }
        _cookIdx = _idxTemp;
        isCookingStart = true;

        ResetToolsPos();   // 도구위치 초기화
        TabletManager.instance.UIStartGameEvent();
        CookManager.instance.Spawn(_cookIdx);


    }

    #region GameStart


    public void ResetToolsPos()
    {
        for (int i = 0; i < _tools.Length; i++)
        {
            _tools[i].transform.position = _toolsPos[i].position;
            _tools[i].transform.rotation = _toolsPos[i].rotation;
        }
    }

    #endregion



    public void StopCooking()
    {
        if (!isCookingStart) return;

        isCookingStart = false;

        TabletManager.instance.UIEndGameEvent();

    }

    #region GameEnd

    #endregion


    public void CampingExpCheck(float exp)
    {
        _currentExp += exp;
        if (_needExp - _currentExp <= 0)
        {
            _level++;

            TabletManager.instance._levelText.text = $"캠핑 레벨 : {_level}";
            _currentExp -= _needExp;
        }
        TabletManager.instance._expSlider.value = _needExp - _currentExp;
    }

    public void SelectCookIdx(int idx)
    {
        _idxTemp = idx;
        TabletManager.instance.SelectRecipe(_idxTemp);


    }
}
