using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooked_Ingredient : MonoBehaviour, IState
{
    public enum Cooked_State    // 요리 상태
    {
        Raw = 0,    // 안 익힘
        Cook,       // 익힘
        Burned,     // 탐
        
    }

    public Cooked_State _cooked_State { get; private set; }      // 굽기단계

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }

    public void Change_Cooked_State(Cooked_State start_State)//상태 변화 메서드
    {
        if (_cooked_State.Equals(start_State)) return;

        OnExit();
        _cooked_State = start_State;

        OnEnter();
    }

}
