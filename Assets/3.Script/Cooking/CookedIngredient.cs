using UnityEngine;

public class CookedIngredient : MonoBehaviour
{
    public enum Cooked_State    // �丮 ����
    {
        Raw = 0,        // ����
        Cook = 1,       // ����
        Burned = 2,     // Ÿ��
    }

    public Cooked_State cookedState { get; private set; }      // ����ܰ�

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
        if (cookedState.Equals(start_State)) return;

        OnExit();
        cookedState = start_State;

        OnEnter();
    }
}
