using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRAlyxGrabInteractable : XRGrabInteractable
{
    public float _veloThreshold = 2f;
    public float jumpAngleInDegree = 60f;

    private XRRayInteractor _rayInter;
    private Vector3 _previousPos;
    private Rigidbody _interactableRigid;
    private bool canJump = true;

    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    protected override void Awake()
    {
        base.Awake();
        _interactableRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isSelected && firstInteractorSelecting is XRRayInteractor && canJump)
        {
            Vector3 velo = (_rayInter.transform.position - _previousPos) / Time.deltaTime;
            _previousPos = _rayInter.transform.position;

            if (velo.magnitude > _veloThreshold)
            {
                Drop();
                _interactableRigid.velocity = ComputeVelocity();
                canJump = false;
            }
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRRayInteractor)
        {
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;

            _rayInter = (XRRayInteractor)args.interactorObject;
            _previousPos = _rayInter.transform.position;

            canJump = true;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }

        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            Debug.Log("¿À¸¥¼Õ");
            attachTransform = rightAttachTransform;
        }

        base.OnSelectEntered(args);
    }

    public Vector3 ComputeVelocity()
    {
        Vector3 diff = _rayInter.transform.position - transform.position;
        Vector3 diffXZ = new Vector3(diff.x, 0, diff.z);
        float diffXZLength = diffXZ.magnitude;
        float diffYLength = diff.y;

        float angleInRadian = jumpAngleInDegree * Mathf.Deg2Rad;

        float jumpSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(diffXZLength, 2) /
            (2 * Mathf.Cos(angleInRadian) * Mathf.Cos(angleInRadian) *
            (diffXZ.magnitude * Mathf.Tan(angleInRadian) - diffYLength)));

        Vector3 jumpVeloVector = diffXZ.normalized *
            Mathf.Cos(angleInRadian) * jumpSpeed + Vector3.up * Mathf.Sin(angleInRadian) * jumpSpeed;

        return jumpVeloVector;

    }


}
