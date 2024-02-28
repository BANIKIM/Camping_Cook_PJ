using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int _level = 1;
    public float _needExp = 100f;
    public float _currentExp = 0f;

}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameData _gameData;

    public GameObject[] _tools;
    public Transform[] _toolsPos;

    public int _level = 1;
    public float _needExp = 100f;


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

        SaveToolsData();
    }

    private void SaveToolsData()
    {
        _toolsPos = new Transform[_tools.Length];

        for (int i = 0; i < _tools.Length; i++)
        {
            _toolsPos[i].position = _tools[i].transform.position;
        }
    }

    public void ResetToolsPos()
    {
        for (int i = 0; i < _tools.Length; i++)
        {
            _tools[i].transform.position = _toolsPos[i].position;
        }
    }








}
