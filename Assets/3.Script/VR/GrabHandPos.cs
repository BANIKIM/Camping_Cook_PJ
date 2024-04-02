using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GrabHandPos : MonoBehaviour
{
    public float _posTransitionDuration = 0.2f;
    public HandData _rightHandPos;
    public HandData _leftHandPos;

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
        _leftHandPos.gameObject.SetActive(false);

    }

    public void SetupPos(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRRayInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData._animator.enabled = false;

            if (handData.Equals(HandData.HandType.Right))
            {
                SetHandDataValues(handData, _rightHandPos);
            }
            else
            {
                SetHandDataValues(handData, _leftHandPos);
            }

            SetHandDataValues(handData, _rightHandPos);
            StartCoroutine(SetHandDataRoutine(handData, _finalHandPos, _finalHandRot, _finalFingerRots,
                _startingHandPos, _startingHandRot, _startingFingerRots));

        }
    }

    public void UnSetPos(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRRayInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData._animator.enabled = true;

            StartCoroutine(SetHandDataRoutine(handData, _startingHandPos, _startingHandRot, _startingFingerRots
                , _finalHandPos, _finalHandRot, _finalFingerRots));
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

    public IEnumerator SetHandDataRoutine(HandData hand, Vector3 newPos, Quaternion newRot, Quaternion[] newBonesRot
        , Vector3 startingPos, Quaternion startingRot, Quaternion[] startingBonesRot)
    {
        float timer = 0f;

        while (timer < _posTransitionDuration)
        {
            Vector3 p = Vector3.Lerp(startingPos, newPos, timer / _posTransitionDuration);
            Quaternion r = Quaternion.Lerp(startingRot, newRot, timer / _posTransitionDuration);

            hand._root.localPosition = p;
            hand._root.localRotation = r;

            for (int i = 0; i < newBonesRot.Length; i++)
            {
                hand._fingerBones[i].localRotation = Quaternion.Lerp(startingBonesRot[i], newBonesRot[i], timer / _posTransitionDuration);
            }

            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

    }

#if UNITY_EDITOR
    // 유니티 엔진 내 도구탭
    [MenuItem("Tools/Mirror Selected Right Grab Pos")]
    public static void MirrorRightPos()
    {
        Debug.Log("Mirror Right Pos");
        GrabHandPos handPos = Selection.activeGameObject.GetComponent<GrabHandPos>();
        handPos.MirrorPos(handPos._leftHandPos, handPos._rightHandPos);
    }

#endif

    // 반대 손 동기화
    public void MirrorPos(HandData posToMirror, HandData posUsedToMirror)
    {
        Vector3 mirroredPos = posUsedToMirror._root.localPosition;
        mirroredPos.x *= -1;

        Quaternion mirroredQuaternion = posUsedToMirror._root.localRotation;
        mirroredQuaternion.y *= -1;
        mirroredQuaternion.z *= -1;

        posToMirror._root.localPosition = mirroredPos;
        posToMirror._root.localRotation = mirroredQuaternion;

        for (int i = 0; i < posUsedToMirror._fingerBones.Length; i++)
        {
            posToMirror._fingerBones[i].localRotation = posUsedToMirror._fingerBones[i].localRotation;
        }
    }
}
