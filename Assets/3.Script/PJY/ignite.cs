using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignite : MonoBehaviour
{
    public GameObject fire;

    // ��ư�� ���� �� ȣ���� �޼���
    public void ToggleFire()
    {
        // fire ���� ������Ʈ�� Ȱ��ȭ ���¸� ���
        fire.SetActive(!fire.activeSelf);
    }
}