using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void RoastOnEnter();
    void RoastOnUpdate();
    void RoastOnExit();
}

public enum Ingredient_Type
{
    Beef = 0,
    Tomahawk,
    Lamb,
    Chicken,
    Sausage,
    Mashmellow,
    Salmon,
    Shrimp,
    Lobster,
    Tomato,
    Potato = 10,
    Carrot,
    Onion,
    Lemon,
    Cabbage,
    Corn,
    Broccoli,
    paprika,
    Garlic,
    GreenOnion,
    Asparagus = 20,
    White_Mushroom,
}

public enum Cooked_State    // 요리 상태
{
    Raw = 0,
    Roasted,    // 굽기
    Boiled,     // 끓이기
    Burned,
}

public enum Slice_State    // 자르기
{
    Default = 0,
    Slice_Step1,
    Slice_Step2,
    Slice_Step3,
}

public class Ingredient : MonoBehaviour, IState
{
    public Ingredient_Type ingredient_type;
    public Cooked_State cooked_state;      // 굽기단계
    public Slice_State slice_state;        // 자르기단계

    [SerializeField] private GameObject[] next_slice_objs;

    [Range(1, 5)]
    [SerializeField] protected int max_slice_count = 1;
    public int current_slice_count = 0;

    private IEnumerator sliceobj_Co;

    public void RoastOnEnter()
    {

    }

    public void RoastOnUpdate()
    {

    }

    public void RoastOnExit()
    {

    }

    private void Start()
    {
        cooked_state = Cooked_State.Raw;
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

    public void ChangeCookState(Cooked_State start_state)
    {
        RoastOnExit();

        cooked_state = start_state;
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



}
