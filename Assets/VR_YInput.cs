using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System.Collections;

public class VR_YInput : MonoBehaviour
{
    public InputActionReference HandCanvas;
    public GameObject Canvas1;
    public GameObject Canvas2;

    private bool isCanvasActive = false;
    private bool isButtonPressed = false;

    private void OnEnable()
    {
        HandCanvas.action.started += OnButtonPress;
        HandCanvas.action.canceled += OnButtonRelease;
    }

    private void OnDisable()
    {
        HandCanvas.action.started -= OnButtonPress;
        HandCanvas.action.canceled -= OnButtonRelease;
    }

    private IEnumerator CheckLongPress()
    {
        yield return new WaitForSeconds(2f);

        if (isButtonPressed)
        {
            // 2초 이상 버튼이 눌려 있는 경우
            isCanvasActive = false;
            Canvas1.SetActive(isCanvasActive);
            Canvas2.SetActive(true);
        }
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        isButtonPressed = true;
        isCanvasActive = !isCanvasActive;
        Canvas1.SetActive(isCanvasActive);
        StartCoroutine(CheckLongPress());
    }

    private void OnButtonRelease(InputAction.CallbackContext context)
    {
        isButtonPressed = false;
        StopAllCoroutines();
    }
}
