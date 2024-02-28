using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class GrabHandPos : MonoBehaviour
{
    public HandData _rightHandPos;

    private Vector3 _startingHandPos;
    private Vector3 _finalHandPos;
    private Quaternion _startingHandRot;
    private Quaternion _finalHandRot;

    private Quaternion[] _startingFingerRots;
    private Quaternion[] _finalFingerRots;


    private void Start()
    {
        XRGrabInteractable _grabInter = GetComponent<XRGrabInteractable>();

        _grabInter.selectEntered.AddListener(SetupPos);
        _grabInter.selectExited.AddListener(UnSetPos);

        _rightHandPos.gameObject.SetActive(false);

    }

    public void SetupPos(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRRayInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData._animator.enabled = false;


            SetHandDataValues(handData, _rightHandPos);
            SetHandData(handData, _finalHandPos, _finalHandRot, _finalFingerRots);

        }
    }

    public void UnSetPos(BaseInteractionEventArgs arg)
    {
        if(arg.interactorObject is XRRayInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData._animator.enabled = true;

            SetHandData(handData, _startingHandPos, _startingHandRot, _startingFingerRots);
        }
    }


    public void SetHandDataValues(HandData hand1, HandData hand2)
    {
        _startingHandPos = new Vector3(hand1._root.localPosition.x / hand1._root.localScale.x,
            hand1._root.localPosition.y / hand1._root.localScale.y, hand1._root.localPosition.z / hand1._root.localScale.z);
        _finalHandPos = new Vector3(hand2._root.localPosition.x / hand2._root.localScale.x,
            hand2._root.localPosition.y / hand2._root.localScale.y, hand2._root.localPosition.z / hand2._root.localScale.z);

        _startingHandRot = hand1._root.localRotation;
        _finalHandRot = hand2._root.localRotation;

        _startingFingerRots = new Quaternion[hand1._fingerBones.Length];
        _finalFingerRots = new Quaternion[hand1._fingerBones.Length];

        for (int i = 0; i < hand1._fingerBones.Length; i++)
        {
            _startingFingerRots[i] = hand1._fingerBones[i].localRotation;
            _finalFingerRots[i] = hand2._fingerBones[i].localRotation;

        }

    }

    public void SetHandData(HandData hand, Vector3 newPos, Quaternion newRot, Quaternion[] newBonesRot)
    {
        hand._root.localPosition = newPos;
        hand._root.localRotation = newRot;

        for (int i = 0; i < newBonesRot.Length; i++)
        {
            hand._fingerBones[i].localRotation = newBonesRot[i];
        }
    }

}
