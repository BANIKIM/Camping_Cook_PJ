using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooked_Ingredient : MonoBehaviour, IState
{
    public enum Cooked_State    // 요리 상태
    {
        Raw = 0, //날것
        Cook,    // 익힘
        Burned,     // 타다
        
    }

    private void Update()
    {
    }

    public Cooked_State cooked_state { get; private set; }      // 굽기단계

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }

    public void Change_Skewer_State(Cooked_State start_state)//상태 변화 메서드
    {
        if (cooked_state.Equals(start_state)) return;

        OnExit();
        cooked_state = start_state;

        OnEnter();
    }

}
