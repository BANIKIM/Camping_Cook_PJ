using EzySlice;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Knife : MonoBehaviour
{
    public Transform _startPos;
    public Transform _endPos;
    public VelocityEstimator _velocityEstimator;

    public float cutForce = 100f;

    public LayerMask targetLayer;

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(_startPos.position, _endPos.position, out RaycastHit hit, targetLayer);

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            SliceObj(target);
        }
    }

    public void SliceObj(GameObject target)
    {
        Vector3 velo = _velocityEstimator.GetVelocityEstimate();
        Vector3 slice_normal = Vector3.Cross(_endPos.position - _startPos.position, velo);
        Material cross = target.GetComponent<Ingredient>()._crossMat;
        slice_normal.Normalize();

        SlicedHull hull = target.Slice(_endPos.position, slice_normal);

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
