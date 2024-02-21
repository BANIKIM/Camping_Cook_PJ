using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VR_XInput : MonoBehaviour
{
    public InputActionReference Xbtn;
    public GameObject equipmentPosition;
    public GameObject axe;
    public GameObject torch;

    private bool isHoldingX = false; // X Ű�� �� ������ �ִ��� ���θ� ��Ÿ���� �÷���
    private float holdDuration = 1f; // X Ű�� �� ���� ���� �ð�
    private float currentHoldTime = 0f; // ���� X Ű�� �� ���� �ð�

    private void OnEnable()
    {
        // X Ű �Է� �׼ǿ� ���� ������ ���
        Xbtn.action.started += OnXButtonPressed;
        Xbtn.action.canceled += OnXButtonReleased;
    }

    private void OnDisable()
    {
        // X Ű �Է� �׼ǿ� ���� ������ ����
        Xbtn.action.started -= OnXButtonPressed;
        Xbtn.action.canceled -= OnXButtonReleased;
    }

    private void Update()
    {
        // X Ű�� �� ������ �ִ� ���� ������ ��ġ�� equipmentPosition ��ġ�� �̵�
        if (isHoldingX)
        {
            currentHoldTime += Time.deltaTime; // ���� �� ���� �ð� ����
            if (currentHoldTime >= holdDuration) // ������ �ð� �̻� �� ���� ���
            {
                // ������ ��ġ�� equipmentPosition ��ġ�� �̵�
                axe.transform.position = equipmentPosition.transform.position;
                Vector3 torchPosition = equipmentPosition.transform.position + new Vector3(0.3f, 0f, 0f); // ���������� 0.1��ŭ �̵�
                torch.transform.position = torchPosition;
            }
        }
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        // X Ű�� ���� ���
        isHoldingX = true;
        currentHoldTime = 0f;
    }

    private void OnXButtonReleased(InputAction.CallbackContext context)
    {
        // X Ű�� ���� ���
        isHoldingX = false;
        currentHoldTime = 0f;
    }

}
