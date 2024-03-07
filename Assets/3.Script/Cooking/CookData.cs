using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cook Data", menuName = "Scriptable Object/Cook Data", order = int.MaxValue)]
public class CookData : ScriptableObject
{
    

    [SerializeField] private string _cookName;
    public string CookName { get { return _cookName; } }

    [SerializeField] private Cooking_Difficulty  _difficulty;
    public Cooking_Difficulty Difficulty { get { return _difficulty; } }

    [SerializeField] private int _reward;
    public int Reward { get { return _reward; } }
}
