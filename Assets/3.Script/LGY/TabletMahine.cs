using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TabletMahine : MonoBehaviour
{
    public enum TabletMod { Secret, Handed, World }

    private TabletMod _tabletMod;

    public InputActionReference HandCanvas;

    public GameObject _tablet;
    public Transform _handPos;

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
            // 2�� �̻� ��ư�� ���� �ִ� ���
            isCanvasActive = false;
            Canvas1.SetActive(isCanvasActive);
            Canvas2.transform.position = TruePosition.transform.position; // ĵ����2�� ��ġ�� TruePosition���� ����
            Canvas2.transform.rotation = TruePosition.transform.rotation; // ĵ����2�� ȸ��
            Canvas2.SetActive(true);
        }
    }

    private void OnButtonPress(InputAction.CallbackContext context)
    {
        switch (_tabletMod)
        {
            case TabletMod.Secret:
                break;
            case TabletMod.Handed:
                break;
            case TabletMod.World:
                break;
            default:
                break;
        }



        isButtonPressed = true;
        isCanvasActive = !isCanvasActive;
        Canvas1.SetActive(isCanvasActive);
        Canvas2.SetActive(false);
        StartCoroutine(CheckLongPress());
    }

    private void OnButtonRelease(InputAction.CallbackContext context)
    {
        switch (_tabletMod)
        {
            case TabletMod.Secret:
                break;
            case TabletMod.Handed:
                break;
            case TabletMod.World:
                break;
            default:
                break;
        }



        isButtonPressed = false;
        StopAllCoroutines();
    }
}
