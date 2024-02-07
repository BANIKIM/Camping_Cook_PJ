using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Slice_State    // 자르기
{
    Default = 0,
    Slice_Step1,
    Slice_Step2,
    Slice_Step3,
}

public class Slice_Obj : MonoBehaviour
{
    public Slice_State slice_state;       // 자르기단계

    [SerializeField] private GameObject[] next_slice_objs;

    [Range(1, 5)]
    [SerializeField] private int max_slice_count = 1;
    public int current_slice_count = 0;

    private IEnumerator sliceobj_Co;


    public void SliceObj()
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
