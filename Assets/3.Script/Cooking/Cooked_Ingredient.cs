using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooked_Ingredient : MonoBehaviour, IState
{
    public enum Cooked_State    // �丮 ����
    {
        Raw = 0,    // �� ����
        Cook,       // ����
        Burned,     // Ž
        
    }

    public Cooked_State _cooked_State { get; private set; }      // ����ܰ�

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }

    public void Change_Cooked_State(Cooked_State start_State)//���� ��ȭ �޼���
    {
        if (_cooked_State.Equals(start_State)) return;

        OnExit();
        _cooked_State = start_State;

        OnEnter();
    }

}
