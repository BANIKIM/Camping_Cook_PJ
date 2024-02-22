using EzySlice;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Knife : MonoBehaviour
{
    public Transform _startPos;
    public Transform _endPos;
    public VelocityEstimator _velocityEstimator;

    public float _cutForce = 100f;

    public LayerMask _targetLayer;

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(_startPos.position, _endPos.position, out RaycastHit hit, _targetLayer);

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            SliceObj(target);
        }
    }

    public void SliceObj(GameObject target)
    {
        Ingredient ingred = target.GetComponent<Ingredient>();
        Vector3 velo = _velocityEstimator.GetVelocityEstimate();
        Vector3 slice_normal = Vector3.Cross(_endPos.position - _startPos.position, velo);
        Material cross = target.GetComponent<Ingredient>()._crossMat;
        slice_normal.Normalize();

        if (ingred._sliceCount <= 2)
        {
            SlicedHull hull = target.Slice(_endPos.position, slice_normal);

            if (hull != null)
            {
                GameObject upperHull = hull.CreateUpperHull(target, cross);
                SetUpSliceCompoent(upperHull, ingred);
                GameObject lowerHull = hull.CreateLowerHull(target, cross);
                SetUpSliceCompoent(lowerHull, ingred);

                Destroy(target);
            }
        }
    }

    private void SetUpSliceCompoent(GameObject obj, Ingredient target_ingred)
    {
        MeshCollider mesh = obj.AddComponent<MeshCollider>();
        mesh.convex = true;

        Ingredient ingred = obj.AddComponent<Ingredient>();
        ingred.DataSetting(target_ingred);

        obj.AddComponent<Cooking>();

        obj.AddComponent<XRGrabInteractable>();

        obj.layer = 6;
    }

}
