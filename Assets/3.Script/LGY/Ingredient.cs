using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
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

public enum Cooked_State    // �丮 ����
{
    Raw = 0,
    Roasted,    // ����
    Boiled,     // ���̱�
    Burned,
}

public enum Slice_State    // �ڸ���
{
    Default = 0,
    Slice_Step1,
    Slice_Step2,
    Slice_Step3,
}

public class Ingredient : MonoBehaviour, IState
{
    // �̰� �� ������ ������
    public Ingredient_Type ingredient_type;
    public Cooked_State cooked_state;      // ����ܰ�
    public Slice_State slice_state;        // �ڸ���ܰ�

    [SerializeField] private GameObject[] next_slice_objs;

    [Range(1, 5)]
    [SerializeField] protected int max_slice_count = 1;
    public int current_slice_count = 0;

    private IEnumerator sliceobj_Co;

    public void OnEnter()
    {

    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }

    private void Start()
    {
        cooked_state = Cooked_State.Raw;
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

    public void ChangeCookState(Cooked_State start_state)
    {
        OnExit();

        cooked_state = start_state;
        OnEnter();
    }

    private void SliceObj()     // FSM �������� 
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
