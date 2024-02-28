using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable //기존에 있는 스크립트 오버라이드 해서 사용
{

    public Transform leftAttachTransform;
    public Transform rightAttachTransform;


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            Debug.Log("오른손");
            attachTransform = rightAttachTransform;
        }
        base.OnSelectEntered(args);
    }
}
