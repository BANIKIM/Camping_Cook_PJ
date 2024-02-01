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

public enum Slice_State
{
    Default = 0,
    Slice_Step1,
    Slice_Step2,
    Slice_Step3,
}

public abstract class Food : MonoBehaviour, IState
{
    public Cook_State cook_state;      // 굽기단계
    public Slice_State slice_state;    // 자르기단계

    [SerializeField] private GameObject[] next_slice_objs;

    [Range(1, 5)]
    [SerializeField] protected int max_slice_count = 1;
    public int current_slice_count = 0;

    public virtual void OnEnter()
    {
        current_slice_count = 0;
    }

    public abstract void OnUpdate();

    public abstract void OnExit();

    private IEnumerator sliceobj_Co;


    private void Start()
    {
        cook_state = Cook_State.Raw;
        OnEnter();
    }

    private void Update()
    {
        OnUpdate();
    }

    private void FixedUpdate()
    {
        SliceObj();   
    }

    public void ChangeCookState(Cook_State start_state)
    {
        OnExit();

        cook_state = start_state;
        OnEnter();
    }

    private void SliceObj()     // FSM 패턴으로 
    {
        if (current_slice_count.Equals(max_slice_count))
        {
            SliceObjActive(next_slice_objs);
        }
    }

    private void SliceObjActive(GameObject[] objs)
    {
        sliceobj_Co = SliceObj_co(objs);
        StartCoroutine(sliceobj_Co);
    }

    private IEnumerator SliceObj_co(GameObject[] objs)
    {
        gameObject.SetActive(false);
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(true);
            objs[i].transform.parent = null;
        }

        Destroy(gameObject);

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Knife"))
        {
            current_slice_count++;
        }
    }

}
