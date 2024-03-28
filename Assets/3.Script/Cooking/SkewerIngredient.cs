using UnityEngine;

public enum Skewer_State
{
    Idle = 0,
    Inserted,
}

public class SkewerIngredient : MonoBehaviour, IState
{
    private Rigidbody rigid;
    private MeshCollider meshCol;
    public bool isSkewer;

    public Skewer_State skewer_state { get; private set; }

    private void Start()
    {
        skewer_state = Skewer_State.Idle;
        TryGetComponent(out rigid);
        TryGetComponent(out meshCol);
        if (isSkewer)
        {
            Change_Skewer_State(Skewer_State.Inserted);
        }
    }

    public void OnEnter()
    {
        switch (skewer_state)
        {
            case Skewer_State.Idle:
                rigid.constraints = RigidbodyConstraints.None;
                break;
            case Skewer_State.Inserted:
                rigid.isKinematic = true;
                if (meshCol != null) meshCol.isTrigger = true;
                rigid.constraints = RigidbodyConstraints.FreezeAll;
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
