using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.XR.Interaction.Toolkit;

public class Slice_Obj2 : MonoBehaviour
{
    public LayerMask sliceable_layer;
    private Vector3 presiousPos; // 이전 위치
    public Transform Pos;
    public Material cross;
    private float cutting_speed = 0f;
    private float cut_force = 100f;

    private bool Test = false;


    public void FixedUpdate()
    {

        Debug.DrawRay(transform.position, Vector3.down, Color.red, 5);
        if (Physics.Raycast(Pos.position, Pos.forward, out RaycastHit hit, 0.05f, sliceable_layer))
        {
            if (Test.Equals(false)) SliceObj(hit.transform.gameObject);
            
        }
        presiousPos = transform.position;
    }

    public void SliceObj(GameObject target)
    {
        Test = true;
        Vector3 slice_normal = Vector3.Cross(transform.position - presiousPos, transform.forward);
        SlicedHull hull = target.Slice(target.transform.position, slice_normal);

        if (hull != null)
        {
            GameObject upper_hull = hull.CreateUpperHull(target, cross);
            SetupSlicedComponent(upper_hull);
            GameObject lower_hull = hull.CreateLowerHull(target, cross);
            SetupSlicedComponent(lower_hull);

            Destroy(target);
            Test = false;
        }
    }


    public void SetupSlicedComponent(GameObject slice_obj)
    {
        Rigidbody rigid = slice_obj.AddComponent<Rigidbody>();
        MeshCollider col = slice_obj.AddComponent<MeshCollider>();
        XRGrabInteractable xrgrab = slice_obj.AddComponent<XRGrabInteractable>();
        col.convex = true;
        rigid.AddExplosionForce(cut_force, transform.position, 1);

        slice_obj.gameObject.layer = 6;


    }

}
