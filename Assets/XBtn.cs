using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System.Collections;


public class XBtn : MonoBehaviour
{
    public InputActionReference Xbtn;
    public GameObject woodPrefab;
    public GameObject WoodSpawnPosition;
   


    public int maxCount = 1;

    private int currentCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 컨트롤러인지 확인
        if (other.CompareTag("Hand"))
        {
            // X 버튼을 눌렀을 때 소환 작업 실행
            Xbtn.action.started += OnXButtonPressed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // 충돌한 오브젝트가 컨트롤러인지 확인
        if (other.CompareTag("Hand"))
        {
            // X 버튼을 누르는 이벤트 해제
            Xbtn.action.started -= OnXButtonPressed;
        }
    }
    private void FixedUpdate()
    {
        // 현재 생성된 오브젝트의 개수를 확인하여 currentCount를 업데이트합니다.
        currentCount = GameObject.FindGameObjectsWithTag("Wood").Length;
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        // 이미 최대 개수 이상의 프리팹이 생성되었다면 더 이상 생성하지 않음
        if (currentCount >= maxCount)
        {
            return;
        }

        // woodPrefab이 없는 경우 새로운 프리팹을 생성
        if (woodPrefab == null)
        {
            Debug.LogError("woodPrefab이 할당되지 않았습니다.");
            return;
        }
        // 스크립트가 붙은 오브젝트의 위치에 프리팹 생성하되, y값에 offset을 더한 위치에 생성
        Vector3 spawnPosition = WoodSpawnPosition.transform.position;
        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f); // x축 회전값을 90도로 설정
        Instantiate(woodPrefab, spawnPosition, rotation);
        currentCount++;
    }

} 
