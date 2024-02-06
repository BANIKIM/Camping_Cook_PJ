using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooked_Ingredient : MonoBehaviour, IState
{
    public enum Cooked_State    // ¿ä¸® »óÅÂ
    {
        Raw = 0,
        Roasted,    // ±Á±â
        Boiled,     // ²úÀÌ±â
        Burned,
    }

    private void Update()
    {
    }

    private Cooked_State cooked_state;      // ±Á±â´Ü°è

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }

    public void Change_Skewer_State(Cooked_State start_state)
    {
        if (cooked_state.Equals(start_state)) return;

        OnExit();
        cooked_state = start_state;

        OnEnter();
    }

}
