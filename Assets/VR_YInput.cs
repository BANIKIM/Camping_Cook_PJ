using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System.Collections;

public class VR_YInput : MonoBehaviour
{
    public InputActionReference HandCanvas;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject TruePosition;

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
        yield return new WaitForSeconds(1f);

        if (isButtonPressed)
        {
            // 2초 이상 버튼이 눌려 있는 경우
            isCanvasActive = false;
            Canvas1.SetActive(isCanvasActive);
            Canvas2.transform.position = TruePosition.transform.position; // 캔버스2의 위치를 TruePosition으로 설정
            Canvas2.SetActive(true);
        }
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        isButtonPressed = true;
        isCanvasActive = !isCanvasActive;
        Canvas1.SetActive(isCanvasActive);
        Canvas2.SetActive(false);
        StartCoroutine(CheckLongPress());
    }

    private void OnButtonRelease(InputAction.CallbackContext context)
    {
        isButtonPressed = false;
        StopAllCoroutines();
    }
}
