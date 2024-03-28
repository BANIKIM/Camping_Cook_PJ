using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnime;
    public InputActionProperty gripAnime;
    public Animator handAnime;

    private void Update()
    {
        float triggerValue = pinchAnime.action.ReadValue<float>();
        handAnime.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnime.action.ReadValue<float>();
        handAnime.SetFloat("Grip", gripValue);
    }
}
