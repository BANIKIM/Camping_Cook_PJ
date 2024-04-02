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

    // 요리 시작
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
        _cookIdx = _selectIdx;
        // 60초 쿨타임 나중에 변수로 빼야함
        if (_gameMod.Equals(GameMod.Challenge))
        {
            if (_cookIdx.Equals(3))
            {
                CookManager.instance.Spawn(5); // 모든 재료 있는 프리팹 만들어서 넣어야함
            }
            else
            {
                CookManager.instance.Spawn(6); // 모든 재료 있는 프리팹 만들어서 넣어야함

            }
        }
        else
        {
            CookManager.instance.Spawn(_cookIdx);
        }



        isCookingStart = true;
        TabletManager.instance.UIStartGameEvent(_cookIdx);
        ResetToolsPos();   // 도구위치 초기화



    }

    // 도구 위치 초기화
    public void ResetToolsPos()
    {
        for (int i = 0; i < _tools.Length; i++)
        {
            _tools[i].transform.position = _toolsPos[i].position;
            _tools[i].transform.rotation = _toolsPos[i].rotation;
        }
    }



    // 요리 중지
    public void StopCooking()
    {
        if (!isCookingStart) return;

        isCookingStart = false;

        TabletManager.instance.UIEndGameEvent(_cookIdx);
        GameObject box = GameObject.FindWithTag("Box");
        Destroy(box);
        GameObject[] trash = GameObject.FindGameObjectsWithTag("Food");
        for (int i = 0; i < trash.Length; i++)
        {
            Destroy(trash[i]);
        }
    }

    // 캠핑 경험치 확인
    public void CampingExpCheck(float exp)
    {
        _currentExp += exp; // exp 추가
        if (_needExp <= _currentExp)
        {
            _level++;

            TabletManager.instance._campingLvText.text = $"캠핑 레벨 : {_level}";
            _currentExp -= _needExp;
        }
        TabletManager.instance._campingExpSlider.value = _currentExp;
    }

    // 레시피 선택했을 때
    public void SelectRecipeEvent(int idx)
    {
        _selectIdx = idx;

        TabletManager.instance._tablet_ProgressCook.SelectRecipe(_selectIdx);

    }

    // 뒤로가기 버튼 눌렀을 때
    public void BackBtn()
    {
        TabletManager.instance._gameModText[_selectIdx].text = "일반";
        TabletManager.instance._tablet_ProgressCook.BackBtn();
        _gameMod = GameMod.Default;
    }

    // 게임 모드 변경
    public void ChangeGameMod()
    {
        switch (_gameMod)
        {
            case GameMod.Default:      // 기본 > 챌린지
                _gameMod = GameMod.Challenge;
                break;
            case GameMod.Challenge:    // 챌린지 -> 기본
                _gameMod = GameMod.Default;
                break;
            default:
                break;
        }
        TabletManager.instance.ChangeGameMod(_selectIdx, (int)_gameMod);
    }

}
