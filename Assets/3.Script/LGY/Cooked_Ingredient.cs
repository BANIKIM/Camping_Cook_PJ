using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooked_Ingredient : MonoBehaviour, IState
{
    public enum Cooked_State    // �丮 ����
    {
        Raw = 0,
        Roasted,    // ����
        Boiled,     // ���̱�
        Burned,
    }

    private void Update()
    {
    }

    private Cooked_State cooked_state;      // ����ܰ�

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
