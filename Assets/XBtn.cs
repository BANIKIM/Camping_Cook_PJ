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
        // �浹�� ������Ʈ�� ��Ʈ�ѷ����� Ȯ��
        if (other.CompareTag("Hand"))
        {
            // X ��ư�� ������ �� ��ȯ �۾� ����
            Xbtn.action.started += OnXButtonPressed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // �浹�� ������Ʈ�� ��Ʈ�ѷ����� Ȯ��
        if (other.CompareTag("Hand"))
        {
            // X ��ư�� ������ �̺�Ʈ ����
            Xbtn.action.started -= OnXButtonPressed;
        }
    }
    private void FixedUpdate()
    {
        // ���� ������ ������Ʈ�� ������ Ȯ���Ͽ� currentCount�� ������Ʈ�մϴ�.
        currentCount = GameObject.FindGameObjectsWithTag("Wood").Length;
    }

    private void OnXButtonPressed(InputAction.CallbackContext context)
    {
        // �̹� �ִ� ���� �̻��� �������� �����Ǿ��ٸ� �� �̻� �������� ����
        if (currentCount >= maxCount)
        {
            return;
        }

        // woodPrefab�� ���� ��� ���ο� �������� ����
        if (woodPrefab == null)
        {
            Debug.LogError("woodPrefab�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }
        // ��ũ��Ʈ�� ���� ������Ʈ�� ��ġ�� ������ �����ϵ�, y���� offset�� ���� ��ġ�� ����
        Vector3 spawnPosition = WoodSpawnPosition.transform.position;
        Quaternion rotation = Quaternion.Euler(90f, 0f, 0f); // x�� ȸ������ 90���� ����
        Instantiate(woodPrefab, spawnPosition, rotation);
        currentCount++;
    }

} 
