using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skewer_State
{
    Idle = 0,
    Inserted,
}

public class Skewer_Ingredient : MonoBehaviour, IState
{

    private Rigidbody _rb;
    private MeshCollider _meshCol;

    public Skewer_State skewer_state { get; private set; }

    private void Start()
    {
        skewer_state = Skewer_State.Idle;
        TryGetComponent(out _rb);
        TryGetComponent(out _meshCol);
    }

    public void OnEnter()
    {
        switch (skewer_state)
        {
            case Skewer_State.Idle:
                _rb.constraints = RigidbodyConstraints.None;
                break;
            case Skewer_State.Inserted:
                _rb.isKinematic = true;
                _meshCol.isTrigger = true;
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                break;
            default:
                break;
        }
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }

    public void Change_Skewer_State(Skewer_State start_state)
    {
        if (skewer_state.Equals(start_state)) return;

        OnExit();
        skewer_state = start_state;

        OnEnter();
    }
}
