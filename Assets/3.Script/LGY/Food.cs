using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cooking_State
{
    Raw = 0,
    Cooked,
    Burned, 
}

public abstract class Food : MonoBehaviour
{
    public Cooking_State cooking_state;

    [Range(1, 5)]
    public int slice_count = 1;

    protected int slice_step = 0;    // �ڸ��� �ܰ�

    [Range(0, 5)]
    [SerializeField] protected int max_slice_step = 4;  // �ִ� �ڸ��� �ܰ�

    protected abstract void StateEnter();

    protected abstract void StateUpdate();

    protected abstract void StateExit();

}
