using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice_Obj2 : MonoBehaviour
{
    public Transform knifedebug;
    public GameObject target;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EzySlice_Obj(target);
        }
    }

    public void EzySlice_Obj(GameObject target)
    {
        SlicedHull hull = target.Slice(knifedebug.position, knifedebug.up);

        if(hull !=null)
        {
            GameObject upper_hull = hull.CreateUpperHull(target);
            GameObject lower_hull = hull.CreateLowerHull(target);

            Destroy(target);
        }

    }

}
