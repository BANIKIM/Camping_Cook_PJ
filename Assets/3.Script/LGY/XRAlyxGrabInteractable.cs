using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRAlyxGrabInteractable : XRGrabInteractable
{
    public float _veloThreshold = 2f;

    private XRRayInteractor _rayInter;
    private Vector3 _previousPos;
    private Rigidbody _interactableRigid;
    private bool canJump = true;

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

            if(velo.magnitude > _veloThreshold)
            {
                Drop();
                _interactableRigid.velocity = Vector3.up;
                canJump = false;
            }
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRRayInteractor)
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
        base.OnSelectEntered(args);
    }
}
