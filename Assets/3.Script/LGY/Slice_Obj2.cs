using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using EzySlice;

public class Slice_Obj2 : MonoBehaviour
{
    public Material cross;
    public Transform slice_pos;

    public float cutForce = 100f;

    Vector3 presiousPos;
    public LayerMask target_layer;

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(slice_pos.position, slice_pos.forward, out RaycastHit hit, target_layer);

        if (hasHit)
        {
            if (Vector3.Magnitude(slice_pos.position - presiousPos) >= 0.0001f)
            {
                GameObject target = hit.transform.gameObject;
                SliceObject(target);
            }
        }

        presiousPos = slice_pos.position;

    }

    public void SliceObject(GameObject target)
    {

        Vector3 slice_normal = Vector3.Cross(transform.position - presiousPos, transform.forward);

        SlicedHull hull = target.Slice(target.transform.position, slice_normal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, cross);
            SetUpSliceCompoent(upperHull, target);
            GameObject lowerHull = hull.CreateLowerHull(target, cross);
            SetUpSliceCompoent(lowerHull, target);

            Destroy(target);
        }
    }

    private void SetUpSliceCompoent(GameObject obj, GameObject target)
    {
        Rigidbody rigid = obj.AddComponent<Rigidbody>();
        MeshCollider mesh = obj.AddComponent<MeshCollider>();

        mesh.convex = true;
        rigid.AddExplosionForce(cutForce, obj.transform.position, 1);
        XRGrabInteractable xrgrab = obj.AddComponent<XRGrabInteractable>();

        obj.transform.parent = target.transform.parent;
        obj.layer = 6;

    }

}
