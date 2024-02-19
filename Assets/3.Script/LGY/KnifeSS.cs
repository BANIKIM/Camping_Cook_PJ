using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using EzySlice;

public class KnifeSS : MonoBehaviour
{
    public Material cross;
    public Transform startPos;
    public Transform endPos;
    public VelocityEstimator velocityEstimator;

    public float cutForce = 100f;

    public LayerMask targetLayer;

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startPos.position, endPos.position, out RaycastHit hit, targetLayer); ;

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            SliceObj(target);
        }
    }

    public void SliceObj(GameObject _target)
    {
        Vector3 velo = velocityEstimator.GetVelocityEstimate();
        Vector3 slice_normal = Vector3.Cross(endPos.position - startPos.position, velo);
        slice_normal.Normalize();

        SlicedHull hull = _target.Slice(endPos.position, slice_normal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(_target, cross);
            SetUpSliceCompoent(upperHull, _target);
            GameObject lowerHull = hull.CreateLowerHull(_target, cross);
            SetUpSliceCompoent(lowerHull, _target);

            Destroy(_target);
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
