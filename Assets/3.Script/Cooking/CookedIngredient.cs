using UnityEngine;

public class CookedIngredient : MonoBehaviour
{
    public enum Cooked_State    // 요리 상태
    {
        Raw = 0,        // 날것
        Cook = 1,       // 익힘
        Burned = 2,     // 타다
    }

    public Cooked_State cookedState { get; private set; }      // 굽기단계

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
        if (cookedState.Equals(start_State)) return;

        OnExit();
        cookedState = start_State;

        OnEnter();
    }
}
