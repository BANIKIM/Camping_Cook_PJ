using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public enum GameMod
    {
        Default = 0,
        Challenge = 1,
    }
    public GameMod _gameMod = GameMod.Default;

    // Scriptable Objs
    private CookData _currentCookData;

    [Header("Resource")]
    [SerializeField] private CookData[] _cookDatas;


    [SerializeField] private GameObject[] _tools;
    [SerializeField] private Transform[] _toolsPos;

    public int _level = 1;
    public float _needExp = 100f;
    public float _currentExp = 0f;
    public int _cookIdx;
    private int _selectIdx;

    public int _star = 0;
    public int _trophy = 0;

    public bool isCookingStart = false;
    private IEnumerator _challengeTimerTemp;

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
            if (_selectIdx.Equals(_cookIdx)) return;

            else
            {
                StopCooking();
            }
        }
        // 60초 쿨타임 나중에 변수로 빼야함
        if (_gameMod.Equals(GameMod.Challenge))
        {
            ChallengeTimer(60);
            CookManager.instance.Spawn(5); // 모든 재료 있는 프리팹 만들어서 넣어야함
        }
        else
        {
            CookManager.instance.Spawn(_cookIdx);
        }


        _cookIdx = _selectIdx;
        isCookingStart = true;
        _currentCookData = _cookDatas[_selectIdx];
        ResetToolsPos();   // 도구위치 초기화
        TabletManager.instance.UIStartGameEvent(_cookIdx);


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

    private void ChallengeTimer(float seconds)
    {
        _challengeTimerTemp = ChallengeTimer_Co(seconds);
        StartCoroutine(_challengeTimerTemp);
    }

    private IEnumerator ChallengeTimer_Co(float seconds)
    {
        float currentTime = 60f;

        while (isCookingStart && currentTime > 0)
        {
            currentTime -= Time.fixedDeltaTime;
            TabletManager.instance._tablet_CookingTimer._cookTimerText[_cookIdx].text =
                string.Format("{0:00},{1:00}", (int)currentTime / 60, (int)currentTime % 60);
            yield return new WaitForFixedUpdate();
        }
        StopCooking();
    }


    #endregion



    public void StopCooking()
    {
        if (!isCookingStart) return;

        isCookingStart = false;

        TabletManager.instance.UIEndGameEvent(_cookIdx);

    }

    #region GameEnd

    #endregion


    public void CampingExpCheck(float exp)
    {
        _currentExp += exp;
        if (_needExp <= _currentExp)
        {
            _level++;

            TabletManager.instance._campingLvText.text = $"캠핑 레벨 : {_level}";
            _currentExp -= _needExp;
        }
        TabletManager.instance._campingExpSlider.value = _currentExp;
    }

    public void SelectRecipeEvent(int idx)
    {
        _selectIdx = idx;

        TabletManager.instance._tablet_ProgressCook.SelectRecipe(_selectIdx);

    }

    public void BackBtn()
    {
        TabletManager.instance._gameModText[_selectIdx].text = "일반";
        TabletManager.instance._tablet_ProgressCook.BackBtn();
        _gameMod = GameMod.Default;
    }

    public void ChangeGameMod()
    {
        switch (_gameMod)
        {
            case GameMod.Default:
                _gameMod = GameMod.Challenge;
                break;
            case GameMod.Challenge:
                _gameMod = GameMod.Default;
                break;
            default:
                break;
        }
        TabletManager.instance.ChangeGameMod(_selectIdx, (int)_gameMod);
    }

}
