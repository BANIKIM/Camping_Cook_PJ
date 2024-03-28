using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchanim;
    public InputActionProperty gripanim;
    public Animator handanim;

    private void Update()
    {
        float triggerValue = pinchanim.action.ReadValue<float>();
        handanim.SetFloat("Trigger", triggerValue);

        float gripValue = gripanim.action.ReadValue<float>();
        handanim.SetFloat("Grip", gripValue);

    }
}
