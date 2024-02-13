using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using EzySlice;

public class Slice_Obj2 : MonoBehaviour
{
    private Transform sliceObejct; 
    public GameObject target; 
    public Material cross; 

    public float cutForce = 100f; 

    Vector3 presiousPos; 
    public LayerMask layer;

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 5, layer))
        {
            if (Vector3.Angle(transform.position - presiousPos, hit.transform.up) >= 0) 
            {
                SliceObject(hit.transform.gameObject);
            }
        }

        presiousPos = transform.position;

    }

    public void SliceObject(GameObject target)
    {
        sliceObejct = target.transform.GetChild(1);

        Vector3 slice_normal = Vector3.Cross(transform.position - presiousPos, transform.forward);
        SlicedHull hull = target.Slice(sliceObejct.position, slice_normal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, cross);
            GameObject lowerHull = hull.CreateLowerHull(target, cross);
            if (target.transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject obj = target.transform.GetChild(i).gameObject;
                    SlicedHull hull_c = obj.Slice(sliceObejct.position, slice_normal);

                    if (hull_c != null)
                    {
                        GameObject upper_c = hull_c.CreateUpperHull(obj, cross);
                        GameObject lower_c = hull_c.CreateLowerHull(obj, cross);
                    }
                }
            }

            target.SetActive(false);
            SetUpSliceCompoent(upperHull);
            SetUpSliceCompoent(lowerHull);
        }
    }

    private void SetUpSliceCompoent(GameObject obj)
    {
        XRGrabInteractable xrgrab = obj.AddComponent<XRGrabInteractable>();
        Rigidbody rb = obj.AddComponent<Rigidbody>();
        MeshCollider c = obj.AddComponent<MeshCollider>();

        c.convex = true;
        rb.AddExplosionForce(cutForce, obj.transform.position, 1);
    }

}
