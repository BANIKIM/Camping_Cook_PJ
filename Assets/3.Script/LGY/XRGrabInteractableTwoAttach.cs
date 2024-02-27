using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable //������ �ִ� ��ũ��Ʈ �������̵� �ؼ� ���
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
            Debug.Log("������");
            attachTransform = rightAttachTransform;
        }
        base.OnSelectEntered(args);
    }
}
