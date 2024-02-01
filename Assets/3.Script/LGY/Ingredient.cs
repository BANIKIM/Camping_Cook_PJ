using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void RoastOnEnter();
    void RoastOnUpdate();
    void RoastOnExit();
}

public enum Roast_State
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

public abstract class Ingredient : MonoBehaviour, IState
{
    public Roast_State roast_state;      // 굽기단계
    public Slice_State slice_state;     // 자르기단계

    [SerializeField] private GameObject[] next_slice_objs;

    [Range(1, 5)]
    [SerializeField] protected int max_slice_count = 1;
    public int current_slice_count = 0;

    public abstract void RoastOnEnter();

    public abstract void RoastOnUpdate();

    public abstract void RoastOnExit();

    private IEnumerator sliceobj_Co;


    private void Start()
    {
        roast_state = Roast_State.Raw;
        RoastOnEnter();
    }

    private void Update()
    {
        RoastOnUpdate();
    }

    private void FixedUpdate()
    {
        SliceObj();   
    }

    public void ChangeCookState(Roast_State start_state)
    {
        RoastOnExit();

        roast_state = start_state;
        RoastOnEnter();
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
