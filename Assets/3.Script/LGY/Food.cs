using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();

    void OnUpdate();

    void OnExit();
}

public enum Cook_State
{
    Raw = 0,
    Cooked,
    Burned,
}

public abstract class Food : MonoBehaviour, IState
{
    public Cook_State cook_state;

    [Range(1, 5)]
    protected int max_slice_count = 1;
    public int current_slice_count = 0;


    [Range(0, 5)]
    [SerializeField] protected int max_slice_step = 4;  // 최대 자르기 단계
    protected int slice_step = 0;    // 자르기 단계

    public virtual void OnEnter()
    {
        current_slice_count = 0;
    }

    public abstract void OnUpdate();

    public abstract void OnExit();

    private void Start()
    {
        cook_state = Cook_State.Raw;
        OnEnter();
    }


    private void Update()
    {
        OnUpdate();
    }

    public void ChangeState(Cook_State start_state)
    {
        OnExit();

        cook_state = start_state;
        OnEnter();
    }
}
