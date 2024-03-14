using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VR_XInput : MonoBehaviour
{
    public InputActionReference Xbtn;
    public Transform _axePos;
    public Transform _torchPos;

    public GameObject _axe;
    public GameObject _torch;

    private bool isHoldingX = false; // X 키를 꾹 누르고 있는지 여부를 나타내는 플래그
    private float holdDuration = 1f; // X 키를 꾹 누른 지속 시간
    private float currentHoldTime = 0f; // 현재 X 키를 꾹 누른 시간

    private void OnEnable()
    {
        // X 키 입력 액션에 대한 리스너 등록
        Xbtn.action.started += OnXButtonPressed;
        Xbtn.action.canceled += OnXButtonReleased;
    }

    private void OnDisable()
    {
        // X 키 입력 액션에 대한 리스너 해제
        Xbtn.action.started -= OnXButtonPressed;
        Xbtn.action.canceled -= OnXButtonReleased;
    }

    private void Update()
    {
        // X 키를 꾹 누르고 있는 동안 엑스와 토치를 equipmentPosition 위치로 이동
        if (isHoldingX)
        {
            currentHoldTime += Time.deltaTime; // 현재 꾹 누른 시간 측정
            if (currentHoldTime >= holdDuration) // 지정된 시간 이상 꾹 누른 경우
            {
                // 엑스와 토치를 equipmentPosition 위치로 이동
                _axe.transform.position = _axePos.position;
                _torch.transform.position = _torchPos.position;
            }
        }
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        // X 키가 눌린 경우
        isHoldingX = true;
        currentHoldTime = 0f;
    }

    private void OnXButtonReleased(InputAction.CallbackContext context)
    {
        // X 키가 떼진 경우
        isHoldingX = false;
        currentHoldTime = 0f;
    }

}
