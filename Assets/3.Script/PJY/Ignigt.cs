using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignigt : MonoBehaviour
{
    public GameObject fire;

    // ��ư�� ���� �� ȣ���� �޼���
    public void Fire()
    {
        // fire ���� ������Ʈ�� Ȱ��ȭ ���¸� ���
        fire.SetActive(true);
    }
    public void OffFire()
    {
        fire.SetActive(false);
    }
}